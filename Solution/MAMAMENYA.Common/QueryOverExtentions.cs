using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using NHibernate;


namespace MAMAMENYA
{
    public static class QueryOverExtentions
    {
        private static LambdaExpression GenerateSelector<TEntity>(String propertyName, out Type resultType) where TEntity : class
        {
            // 创建lambda表达式如 (Entity => Entity.OrderByField).
            var parameter = Expression.Parameter(typeof(TEntity), "Entity");
            //  创建选择子包含属性的属性
            PropertyInfo property;
            Expression propertyAccess;
            if (propertyName.Contains('.'))
            {

                String[] childProperties = propertyName.Split('.');
                property = typeof(TEntity).GetProperty(childProperties[0]);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (int i = 1; i < childProperties.Length; i++)
                {
                    property = property.PropertyType.GetProperty(childProperties[i]);
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = typeof(TEntity).GetProperty(propertyName);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }
            resultType = property.PropertyType;
            // 创建排序表达式
            return Expression.Lambda(propertyAccess, parameter);
        }

        private static LambdaExpression GenerateMethodCall<TEntity>(String fieldName) where TEntity : class
        {
            // Type type = typeof(TEntity);
            Type selectorResultType;
            LambdaExpression selector = GenerateSelector<TEntity>(fieldName, out selectorResultType);
            //Expression converted = Expression.Convert(selector.Body, typeof(object));
            //var reuslt = Expression.Lambda<Func<TEntity, object>>(converted, selector.Parameters);
            return selector;
            //Expression<Func<TEntity, object>> result = converted as Expression<Func<TEntity, object>>;

        }

        ///// <summary>
        ///// 按某字段名正序排列
        ///// </summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="source"></param>
        ///// <param name="fieldName"></param>
        ///// <returns></returns>
        //public static IQueryOver<TEntity, TEntity> OrderBy<TEntity>(this IQueryOver<TEntity, TEntity> source, string fieldName) where TEntity : class
        //{
        //    MethodCallExpression resultExp = GenerateMethodCall<TEntity>(source, "OrderBy", fieldName);
        //    return source.OrderBy(resultExp);

        //}


        //private void AddOrder(Func<string, Order> orderStringDelegate, Func<IProjection, Order> orderDelegate)
        //{
        //    if (this.projection != null)
        //    {
        //        this.root.UnderlyingCriteria.AddOrder(orderDelegate(this.projection));
        //    }
        //    else
        //    {
        //        this.root.UnderlyingCriteria.AddOrder(ExpressionProcessor.ProcessOrder(this.path, orderStringDelegate, this.isAlias));
        //    }
        //}

        //// Properties
        //public TReturn Asc
        //{
        //    get
        //    {
        //        this.AddOrder(new Func<string, Order>(Order.Asc), new Func<IProjection, Order>(Order.Asc));
        //        return this.root;
        //    }
        //}

        //public TReturn Desc
        //{
        //    get
        //    {
        //        this.AddOrder(new Func<string, Order>(Order.Desc), new Func<IProjection, Order>(Order.Desc));
        //        return this.root;
        //    }
        //}

        /// <summary>
        /// 按照自定义表达式排序，如 username desc,birth asc
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="source"></param>
        /// <param name="sortExpression"></param>
        /// <returns></returns>
        public static IQueryOver<TEntity, TEntity> OrderUsingSortExpression<TEntity>(this IQueryOver<TEntity, TEntity> source, string sortExpression) where TEntity : class
        {
            String[] orderFields = sortExpression.Split(',');
    
            for (int currentFieldIndex = 0; currentFieldIndex < orderFields.Length; currentFieldIndex++)
            {
                String[] expressionPart = orderFields[currentFieldIndex].Trim().Split(' ');
                String sortField = expressionPart[0];
                Boolean sortDescending = (expressionPart.Length == 2) && (expressionPart[1].Equals("DESC", StringComparison.OrdinalIgnoreCase));
               
                
                source.UnderlyingCriteria.AddOrder(new NHibernate.Criterion.Order(sortField,!sortDescending));
                //bool IsAlias = false;
                //if (sortDescending)
                //{
                //    source.UnderlyingCriteria.AddOrder(
                //        NHibernate.Impl.ExpressionProcessor.ProcessOrder(GenerateMethodCall<TEntity>(sortField),
                //                                        NHibernate.Criterion.Order.Desc, IsAlias));
                //}
                //else
                //{
                //    source.UnderlyingCriteria.AddOrder(
                //      NHibernate.Impl.ExpressionProcessor.ProcessOrder(GenerateMethodCall<TEntity>(sortField),
                //                                       NHibernate.Criterion.Order.Desc, IsAlias));
                //}
            }
            return source;
        }
    }
}
