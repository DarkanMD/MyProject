using NHibernate;

namespace MyProject.Repository
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ISession session) : base(session)
        {
        }
    }
}
