using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public interface IProductRepository : IRepository<Product, string>
    {
        IEnumerable<Product> FindAll();
        IEnumerable<Product> Find(Func<Product, bool> expression);
    }
}
