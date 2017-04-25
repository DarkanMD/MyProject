using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    class Repository<T> : IRepository<T> where T:class
    {
        internal readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;

        }
        public void Save<T1>(T1 entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public void Delete<T1>(T1 entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Delete(entity);
                transaction.Commit();
            }
        }

        //public T1 Get<T1>(long id)
        //{
        //    return _session.QueryOver<T>().Where(c => c.ProductId == id).SingleOrDefault();
        //}
    }
}
