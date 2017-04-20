using NHibernate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class ProductRepository //: IRepository<Product>
    {
        private readonly ISession _session;

        public ProductRepository(ISession session)
        {
            _session = session;
        }

        public void Delete(Product entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Delete(entity);
                transaction.Commit();
            }
        }

        public Product Get(int id)
        {
           return _session.QueryOver<Product>().Where(c => c.ProductId==id).SingleOrDefault();
        }

        public void Save(Product entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }
    }
}
