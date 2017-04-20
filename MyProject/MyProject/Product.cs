using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHibernate.Driver;

namespace MyProject
{
    public class Product
    {

        public Product()
        {
                
        }
        //ctor for reading(with id)
        public Product(int id, string name, string category, decimal price, int stock, string description,
            bool visibility)
        {
            ProductId = id;
            ProductName = name;
            ProductCategory = category;
            ProductPrice = price;
            ProductStock = stock;
            ProductDescription = description;
            ProductVisibility = visibility;

        }

        //ctor for creating products(no id)
        public Product(string name, string category, decimal price, int stock, string description, bool visibility)
        {

            ProductName = name;
            ProductCategory = category;
            ProductPrice = price;
            ProductStock = stock;
            ProductDescription = description;
            ProductVisibility = visibility;

        }
        //public int ProductID { get; private set; }
        //public string ProductName { get; private set; }
        //public string ProductCategory { get; private set; }
        //public decimal ProductPrice { get; private set; }
        //public int ProductStock { get; private set; }
        //public string ProductDescription { get; private set; }
        //public bool ProductVisibility { get; private set; }

        public virtual int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string ProductCategory { get; set; }
        public virtual decimal ProductPrice { get; set; }
        public virtual int ProductStock { get; set; }
        public virtual string ProductDescription { get; set; }
        public virtual bool ProductVisibility { get; set; }
        public virtual decimal Cost()
        {
            return ProductPrice;
        }

        public override string ToString()
        {
            return $"{ProductId} {ProductName} {ProductCategory} {ProductPrice} {ProductStock} {ProductDescription} {ProductVisibility}";
        }
    }


    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.ProductId);
            Map(x => x.ProductName);
            Map(x => x.ProductCategory);
            Map(x => x.ProductPrice);
            Map(x => x.ProductStock);
            Map(x => x.ProductDescription);
            Map(x => x.ProductVisibility);
        }
    }
}
