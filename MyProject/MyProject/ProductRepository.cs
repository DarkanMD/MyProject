using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _dbContext;

        public ProductRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Product Get(string id)
        {
            return _dbContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Product entity)
        {
            _dbContext.Products.Attach(entity);
        }

        public void Delete(Product entity)
        {
            _dbContext.Products.Remove(entity);
        }

        public IEnumerable<Product> FindAll()
        {
            return _dbContext.Products.ToList();
        }

        public IEnumerable<Product> Find(Func<Product, bool> expression)
        {
            return _dbContext.Products.Where(expression).ToList();
        }
    }
}
