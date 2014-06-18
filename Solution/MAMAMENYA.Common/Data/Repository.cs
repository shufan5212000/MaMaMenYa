using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using MAMAMENYA.Core;
using SharpArch.Core;
using SharpArch.Core.DomainModel;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Data.NHibernate;
using MAMAMENYA.Nhibernate;

namespace MAMAMENYA.Data
{


    public class RepositoryWithTypedId<T, IdT> : NHibernateRepositoryWithTypedId<T, IdT>,
                                              Core.IRepositoryWithTypedId<T, IdT> where T : EntityWithTypedId<IdT>
    {
        public RepositoryWithTypedId()
        {

        }
        public IQueryable<T> Query
        {
            get { return GetQuery<T>(); }
        }
        public IQueryOver<T, T> QueryOver
        {
            get
            {
                return Session.QueryOver<T>();
            }
        }
        public IQueryable<U> GetQuery<U>()
        {

            return Session.Query<U>();
        }
        public virtual void Delete(IdT id)
        {
            Session.Transaction.Begin();
            var tablename = typeof(T).FullName;
            Session.Delete(
                string.Format("from  {0}  where Id=? ", tablename)
                       , id
                       , NHibernateUtil.Int32
                   );
            Session.Transaction.Commit();
        }
        public virtual void DeleteAll()
        {
            Session.Transaction.Begin();
            var tablename = typeof(T).FullName;
            Session.Delete(
                string.Format("from  {0}   ", tablename)
                   
                   );
            Session.Transaction.Commit();
        }
        public virtual void ExeSQLQuery(string SQLstring)
        {
            Session.CreateSQLQuery(SQLstring).ExecuteUpdate();
        }

        public virtual IList<T> GetList(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = Query;
            return query.Where(predicate).ToArray();
        }

        public virtual IEnumerable<TResult> GetList<TResult>(Expression<Func<T, bool>> predicate,
                                                             Func<T, TResult> selector)
        {
            IQueryable<T> query = Query;
            return query.Where(predicate).Select(selector);
        }


        public virtual IList<T> GetList(IEnumerable<IdT> ids)
        {
            return ids.Select(c => Get(c)).ToList();
            //IQueryable<T> query = Query;
            //return (from item in ids
            //        join dp in query on item equals dp.Id
            //        select dp).ToList();
        }
        public virtual RecordList<T> GetList<TQ>(TQ query) where TQ : QueryBase
        {
            return GetList(ParseQuery(query), query.PageIndex, query.PageSize);
        }

        public virtual IList<T> GetAll<TQ>(TQ query) where TQ : QueryBase
        {
            return ParseQuery(query).ToList();
        }

        public virtual int GetCount<TQ>(TQ query) where TQ : QueryBase
        {
            return LoadQuery(query).Count();
        }
        public virtual int GetCount()
        {
            return Query.Count();
        }
        public virtual int GetCount(Expression<Func<T, bool>> predicate)
        {
            return Query.Where(predicate).Count();
        }
        public virtual T GetRandom()
        {
            return Session
                .CreateCriteria<T>()
                .AddOrder(new RandomOrder())
                .SetMaxResults(1)
                .UniqueResult<T>();
        }
        public virtual IList<T> GetRandom(int count)
        {
            return Session
                .CreateCriteria<T>()
                .AddOrder(new RandomOrder())
                .SetMaxResults(count)
                .List<T>();
        }
        //public virtual RecordList<TS> GetList<TS, TIdT, TQ>(TQ query)
        //    where TQ : QueryBase
        //    where TS : EntityWithTypedId<TIdT>
        //{
        //    return GetList(ParseQuery<TS, TIdT, TQ>(query), query.PageIndex, query.PageSize);
        //}
        #region  QueryOverAble

        public virtual RecordList<T> GetQueryOverList<TQ>(TQ query) where TQ : QueryBase
        {
            return GetList(ParseQueryOver(query), query.PageIndex, query.PageSize);
        }
        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="lazyLoad">是否延迟加载</param>
        /// <returns></returns>
        protected RecordList<TS> GetList<TS>(IQueryOver<TS, TS> query, int pageindex, int pagesize)
        {

            var records = new RecordList<TS> { PageIndex = pageindex, PageSize = pagesize, RecordCount = query.RowCount() };
            IList<TS> data;
            if (records.RecordCount == 0)
            {
                data = new TS[0];
            }
            else
            {
                do
                {
                    data = records.StartIndex > 0 ? query.Skip(records.StartIndex).Take(pagesize).List() : query.Take(pagesize).List();
                    if (data.Count == 0 && records.PageIndex > 1)
                    {
                        records.PageIndex--;
                    }
                } while (data.Count == 0 && records.PageIndex > 1);
            }
            records.Data = data;
            return records;
        }



        protected RecordList<TS> GetList<TS>(IQueryOver<TS, TS> query, int? pageindex, int? pagesize)
        {
            if (pageindex.HasValue && pagesize.HasValue)
            {
                return GetList(query, pageindex.Value, pagesize.Value);
            }

            var list = new RecordList<TS>(query.List());
            list.RecordCount = list.Count;
            return list;
        }

        protected virtual IQueryOver<T, T> ParseQueryOver<TQ>(TQ query)
            where TQ : QueryBase
        {
            var q = LoadQueryOver(query);
            q = query.OrderBy.NotNullAndEmpty()
                  ? q.OrderUsingSortExpression(query.OrderBy)
                  : q.OrderBy(c => c.Id).Desc;
            return q;
        }

        protected virtual IQueryOver<T, T> LoadQueryOver<TQ>(TQ query) where TQ : QueryBase
        {
            return QueryOver; //LoadQuery<T, IdT, TQ>(query);
        }
        #endregion

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="lazyLoad">是否延迟加载</param>
        /// <returns></returns>
        protected RecordList<TS> GetList<TS>(IQueryable<TS> query, int pageindex, int pagesize)
        {

            var records = new RecordList<TS> { PageIndex = pageindex, PageSize = pagesize, RecordCount = query.Count() };
            IList<TS> data;
            if (records.RecordCount == 0)
            {
                data = new TS[0];
            }
            else
            {
                do
                {
                    data = records.StartIndex > 0 ? query.Skip(records.StartIndex).Take(pagesize).ToList() : query.Take(pagesize).ToList();
                    if (data.Count == 0 && records.PageIndex > 1)
                    {
                        records.PageIndex--;
                    }
                } while (data.Count == 0 && records.PageIndex > 1);
            }
            records.Data = data;
            return records;
        }



        protected RecordList<TS> GetList<TS>(IQueryable<TS> query, int? pageindex, int? pagesize)
        {
            if (pageindex.HasValue && pagesize.HasValue)
            {
                return GetList(query, pageindex.Value, pagesize.Value);
            }

            var list = new RecordList<TS>(query.ToList());
            list.RecordCount = list.Count;
            return list;
        }

        protected virtual IQueryable<T> ParseQuery<TQ>(TQ query)
            where TQ : QueryBase
        {
            var q = LoadQuery(query);
            q = query.OrderBy.NotNullAndEmpty()
                  ? q.OrderUsingSortExpression(query.OrderBy)
                  : q.OrderByDescending(c => c.Id);
            return q;
        }
       public   T GetFirst<TQ>(TQ query) where TQ : QueryBase
        {
            var q = LoadQuery(query);
           return q.FirstOrDefault();
        }
        protected virtual IQueryable<T> LoadQuery<TQ>(TQ query) where TQ : QueryBase
        {
            return Query; //LoadQuery<T, IdT, TQ>(query);
        }

        #region IRepositoryWithTypedId<T,IdT> 成员

        /// <summary>
        /// 是否有符合条件的记录
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual bool Any(Expression<Func<T, bool>> predicate)
        {
            return Query.Any(predicate);
        }
        #endregion
    }

    public class Repository<T> : RepositoryWithTypedId<T, int>, Core.IRepository<T> where T : EntityBase
    {
    }

    public class RepositoryCompositeId<T> : IRepositoryCompositeId<T> where T : IEntityCompositeIdBase
    {
        private IDbContext dbContext;

        protected virtual ISession Session
        {
            get
            {
                string factoryKey = SessionFactoryAttribute.GetKeyFrom(this);
                return NHibernateSession.CurrentFor(factoryKey);
            }
        }

        #region IRepositoryCompositeId<T> Members

        public virtual IDbContext DbContext
        {
            get
            {
                if (dbContext == null)
                {
                    string factoryKey = SessionFactoryAttribute.GetKeyFrom(this);
                    dbContext = new DbContext(factoryKey);
                }

                return dbContext;
            }
        }

        public IQueryable<T> Query
        {
            get { return Session.Query<T>(); }
        }


        public virtual IList<T> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria(typeof(T));
            return criteria.List<T>();
        }


        public virtual void Delete(T entity)
        {
            Session.Delete(entity);
        }

        /// <summary>
        /// Although SaveOrUpdate _can_ be invoked to update an object with an assigned Id, you are 
        /// hereby forced instead to use Save/Update for better clarity.
        /// </summary>
        public virtual T SaveOrUpdate(T entity)
        {
            if (entity.IsSaved)
            {
                Session.Update(entity);
            }
            else
            {
                entity.IsSaved = true;
                Session.Save(entity);
            }


            return entity;
        }

        public RecordList<T> GetList<TQ>(TQ query) where TQ : QueryBase
        {
            return GetList(LoadQuery<T, TQ>(query), query.PageIndex, query.PageSize);
        }
         public T GetFirst<TQ>(TQ query) where TQ : QueryBase
         {
             return LoadQuery(query).FirstOrDefault();
         }
        #endregion

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="lazyLoad">是否延迟加载</param>
        /// <returns></returns>
        protected RecordList<TS> GetList<TS>(IQueryable<TS> query, int pageindex, int pagesize)
        {
            var records = new RecordList<TS> { PageIndex = pageindex, PageSize = pagesize, RecordCount = query.Count() };

            if (records.RecordCount == 0)
            {
                records.Data = new TS[0];
            }
            else
            {
                do
                {
                    records.Data = query.Skip(records.StartIndex).Take(pagesize).ToList();
                    if (records.Count == 0 && records.PageIndex > 1)
                    {
                        records.PageIndex--;
                    }
                } while (records.Count == 0 && records.PageIndex > 1);
            }

            return records;
        }

        protected RecordList<TS> GetList<TS>(IQueryable<TS> query, int? pageindex, int? pagesize)
        {
            if (pageindex.HasValue && pagesize.HasValue)
            {
                return GetList(query, pageindex.Value, pagesize.Value);
            }

            var list = new RecordList<TS> { Data = query.ToList() };
            list.RecordCount = list.Count;
            return list;
        }
        protected RecordList<TS> GetList<TS, TQ>(TQ query) where TQ : QueryBase
        {
            return GetList<TS>(LoadQuery<TS, TQ>(query), query.PageIndex, query.PageSize);
        }

        protected virtual IQueryable<T> LoadQuery<TQ>(TQ query) where TQ : QueryBase
        {
            return LoadQuery<T, TQ>(query);
        }
        protected virtual IQueryable<TS> LoadQuery<TS, TQ>(TQ query) where TQ : QueryBase
        {
            return Session.Query<TS>();
        }


    }

}