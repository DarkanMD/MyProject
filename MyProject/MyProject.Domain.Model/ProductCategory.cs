using System.Collections.Generic;
using MyProject.Domain.Model;

namespace MyProject
{
    public class ProductCategory : Entity
    {
       // public virtual IList<Product> Products { get; set; }
        public ProductCategory()
        {
        }

        public virtual string CategoryName { get; set; }

        //public virtual void AddProduct(Product product)
        //{
        //    Products.Add(product);
        //    product.ProductCategory = this;
        //}
        
    }
}