using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHibernate.Driver;

namespace MyProject
   {
       public enum Type { External, Internal }
    public class Product : Entity
    {

        public Product()
        {
        }
        public virtual string ProductName { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual int ProductIrRange { get; set; }

        public virtual Type Type { get; set; }
        public virtual decimal ProductPrice { get; set; }
        public virtual int ProductStock { get; set; }
        public virtual string ProductDescription { get; set; }
        public virtual bool ProductVisibility { get; set; }

        public override string ToString()
        {
            return $"{Id} {ProductName} {ProductCategory.CategoryName} {ProductPrice} {ProductStock} {ProductDescription} {ProductVisibility}";
        }
    }


    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.ProductName);
            Map(x => x.ProductIrRange);
            Map(x => x.Type);
            References(x => x.ProductCategory);
            Map(x => x.ProductPrice);
            Map(x => x.ProductStock);
            Map(x => x.ProductDescription);
            Map(x => x.ProductVisibility);
        }
    }
}
