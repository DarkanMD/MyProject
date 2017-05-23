using NHibernate;
using System.Collections.Generic;
//using MyProject.Infrastructure;
using Ninject;
using System;
using MyProject.Repository.Interface;
using System.Linq;
using System.Linq.Expressions;
using MyProject.Domain.Model;
using MyProject.Domain.Model;
//using MyProject.Domain.Model;
using NHibernate.Impl;

namespace MyProject.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        internal readonly ISession _session;
        internal readonly ITransaction _transaction;

        public Repository(ISession session, ITransaction transaction)
        {
           _session = session;
            _transaction = transaction;
        }

        public void Save(T entity)
        {
            _session.SaveOrUpdate(entity);
            _transaction.Commit();
       }

        public void Delete(T entity)
        {
            _session.Delete(entity);
            _transaction.Commit();
        }

        public T Get(int id)
        {
                return _session.Get<T>(id);
        }
       public virtual PagedEntity<T> GetPaged (int page, int pageSize,Expression<Func<T,bool>> expression, string ordered)
        {
           // var criteria = _session.CreateCriteria(T,)

           //// mycriteria.AddOrder(NHibernate.Criterion.Order.Desc("name"));
           // PagedEntity<T> result = new PagedEntity<T>();
           // result.Items = _session.QueryOver<T>()
           //     .OrderBy(ordered)
           //     .Desc
           //     .Where(expression)
           //     .Skip((page - 1) * pageSize)
           //     .Take(pageSize)

           //     .List<T>();
           // result.Page = page;
           // result.PageSize = pageSize;
           // result.ItemCount = _session.QueryOver<T>().Where(expression).RowCount();
            return null;

        }


        public IList<T> GetAll()
        {
                return _session.QueryOver<T>()
                    .List<T>();
        }

        public int Count()
        {
            return _session.QueryOver<T>().RowCount();
        }
    }
}
