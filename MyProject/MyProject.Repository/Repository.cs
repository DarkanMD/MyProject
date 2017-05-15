using NHibernate;
using System.Collections.Generic;
using MyProject.Domain.Model;
//using MyProject.Infrastructure;
using Ninject;

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

        public IList<T> GetAll()
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                return _session.QueryOver<T>()
                    .List<T>();
                transaction.Commit();
            }
        }
    }
}
