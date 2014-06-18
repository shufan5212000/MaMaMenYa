using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Engine;
using NHibernate.SqlCommand;
using NHibernate.Type;
using NHibernate.Util;

namespace MAMAMENYA.Nhibernate
{
    [Serializable]
    public class BetterSqlCriterion : AbstractCriterion
    {
        private string _sql;
        private readonly TypedValue[] _typedValues;

        public BetterSqlCriterion(string sql)
            : this(sql, ArrayHelper.EmptyObjectArray, ArrayHelper.EmptyTypeArray)
        {
        }

        public BetterSqlCriterion(string sql, object value, IType type)
            : this(sql, new[] { value }, new[] { type })
        {
        }

        public BetterSqlCriterion(string sql, object[] values, IType[] types)
        {
            _sql = sql;
            _typedValues = new TypedValue[values.Length];
            for (int i = 0; i < _typedValues.Length; i++)
            {
                _typedValues[i] = new TypedValue(types[i], values[i], EntityMode.Poco);
            }
        }

        /// 
        /// Render a SqlString for the expression.
        /// 
        /// 
        /// A SqlString that contains a valid Sql fragment.
        /// 
        public override SqlString ToSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            //TODO:注释了下面，因为3.1移除了.AddUsedTypedValues方法，暂时没找到解决方案
           // criteriaQuery.AddUsedTypedValues(GetTypedValues(criteria, criteriaQuery));

            var columns = Regex.Matches(_sql, @"\{(.*?)\}");

            foreach (Match column in columns)
            {
                var columnName = column.Groups[1].Value;

                var columnNames = CriterionUtil.GetColumnNames(columnName, null, criteriaQuery, criteria, null);
                if (columnNames.Length != 1)
                {
                    throw new HibernateException(string.Format("You can only alias single-column properties: {0}", column.Value));
                }
                _sql = _sql.Replace(column.Value, columnNames[0].ToString());
            }

            return SqlString.Parse(_sql);
        }

        /// 
        /// Return typed values for all parameters in the rendered SQL fragment
        /// 
        /// 
        /// An array of TypedValues for the Expression.
        /// 
        public override TypedValue[] GetTypedValues(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return _typedValues;
        }

        /// 
        /// Return all projections used in this criterion
        /// 
        /// 
        /// An array of IProjection used by the Expression.
        /// 
        public override IProjection[] GetProjections()
        {
            return null;
        }

        /// 
        /// Gets a string representation of the .  
        /// 
        /// 
        /// A String that shows the contents of the .
        /// 
        /// 
        /// This is not a well formed Sql fragment.  It is useful for logging what the 
        ///             looks like.
        /// 
        public override string ToString()
        {
            return this._sql;
        }

    
    }
 
}
