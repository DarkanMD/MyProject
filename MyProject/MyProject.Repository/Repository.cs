using NHibernate;
using System.Collections.Generic;
using MyProject.Domain.Model;
//using MyProject.Infrastructure;
using Ninject;
using System;
using MyProject.Repository.Interface;
using System.Linq;
using System.Linq.Expressions;

namespace MyProject.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        internal readonly ISession _session;

        public Repository(ISession session)
        {
           _session = session;
        }

        public void Save(T entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public void Delete(T entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Delete(entity);
                transaction.Commit();
            }
        }

        public T Get(int id)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                return _session.Get<T>(id);
                transaction.Commit();

            }
        }
        public PagedEntity<T> GetPaged (int page, int pageSize,Expression<Func<T,bool>> expression, Expression<Func<T, object>> ordered)
        {
            PagedEntity<T> result = new PagedEntity<T>();
            result.Items = _session.QueryOver<T>()
                .OrderBy(ordered).Desc
                .Where(expression)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .List<T>();
            result.Page = page;
            result.PageSize = pageSize;
            result.ItemCount = _session.QueryOver<T>().Where(expression).RowCount();
            return result;
        }


        public IList<T> GetAll()
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                return _session.QueryOver<T>()
                    .List<T>();
                transaction.Commit();
            }
        }

        public int Count()
        {
            return _session.QueryOver<T>().RowCount();
        }
    }
}
