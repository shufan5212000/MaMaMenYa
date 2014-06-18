using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SharpArch.Core.PersistenceSupport;

namespace MAMAMENYA.Core
{

    public interface IRepositoryBase<T>
    {

        RecordList<T> GetList<TQ>(TQ query) where TQ : QueryBase;
        T GetFirst<TQ>(TQ query) where TQ : QueryBase;

    }

    public interface IRepositoryWithTypedId<T, IdT> : SharpArch.Core.PersistenceSupport.NHibernate.INHibernateRepositoryWithTypedId<T, IdT>, IRepositoryBase<T>
    {

      //  IQueryable<T> Query { get; }
        /// <summary>
        /// 是否有符合条件的记录
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Any(Expression<Func<T, bool>> predicate);

        //RecordList<TS> GetList<TS, TIdT, TQ>(TQ query)
        //    where TQ : QueryBase
        //    where TS : EntityWithTypedId<TIdT>;
        IList<T> GetList(Expression<Func<T, bool>> predicate);

        IEnumerable<TResult> GetList<TResult>(Expression<Func<T, bool>> predicate, Func<T, TResult> selector);
        IList<T> GetList(IEnumerable<IdT> ids);
        IList<T> GetAll<TQ>(TQ query) where TQ : QueryBase;
        void Delete(IdT id);
        void DeleteAll();
        void ExeSQLQuery(string StrSql);
    }

    public interface IRepository<T> : IRepositoryWithTypedId<T, int>
    {
        int GetCount<TQ>(TQ query) where TQ : QueryBase;
        int GetCount();
        int GetCount(Expression<Func<T, bool>> predicate);
        T GetRandom();
        IList<T> GetRandom(int count);
        
    }

    public interface IRepositoryCompositeId<T> : IRepositoryBase<T> where T : IEntityCompositeIdBase
    {
        IQueryable<T> Query { get; }
        IList<T> GetAll();
        T SaveOrUpdate(T entity);
        void Delete(T entity);
    }

    //public interface IRepositoryWithTypedId<T, IdT> : SharpArch.Core.PersistenceSupport.IRepositoryWithTypedId<T, IdT>
    //{
    //    IList<T> GetList(Expression<Func<T, bool>> predicate);
    //    /// <summary>
    //    /// 是否有符合条件的记录
    //    /// </summary>
    //    /// <param name="predicate"></param>
    //    /// <returns></returns>
    //    bool Any(Expression<Func<T, bool>> predicate);
    //    IEnumerable<TResult> GetList<TResult>(Expression<Func<T, bool>> predicate, Func<T, TResult> selector);
    //    IQueryable<T> Query { get; }
    //    T Load(IdT id);
    //    IList<T> GetList(IList<IdT> ids);
    //    T Save(T item);
    //    T Update(T item);
    //}

    //public interface IRepository<T> : IRepositoryWithTypedId<T, int>
    //{

    //}
    //public interface IRepositoryCompositeId<T> where T : IEntityCompositeIdBase
    //{
    //    IDbContext DbContext { get; }
    //    IList<T> GetAll();
    //    T SaveOrUpdate(T entity);
    //    void Delete(T entity);
    //}
}