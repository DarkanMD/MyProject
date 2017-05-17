using NHibernate;

namespace MyProject.Repository
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ISession session,  ITransaction transaction) : base(session, transaction)
        {
        }
    }
}
