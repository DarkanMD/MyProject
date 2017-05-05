using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace MyProject
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        internal readonly ISession _session;

        public Repository()
        {
            var kernel = new StandardKernel(Bindings.Instance);
            _session = kernel.Get<ISession>();
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
            return _session.Get<T>(id);
        }
    }
}
