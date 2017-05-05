using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace MyProject
{
    public class ProductCategory : Entity
    {
        public virtual IList<Product> Products { get; set; }
        public ProductCategory()
        {
        }

        public virtual string CategoryName { get; set; }

        public virtual void AddProduct(Product product)
        {
            Products.Add(product);
            product.ProductCategory = this;

        }
        
    }

    public class ProductCategoryMap : ClassMap<ProductCategory>
    {
        public ProductCategoryMap()
        {
            Id(x => x.Id);
            Map(x => x.CategoryName);
            HasMany(x => x.Products).Inverse();
        }
    }
}