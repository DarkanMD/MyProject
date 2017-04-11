using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class Product : AbstractProduct
    {
        //ctor for reading(with id)
        public Product(int id, string name,string category,decimal price, int stock, string description, bool visibility)
        {
            ProductID = id;
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

        public decimal Cost()
        {
            return ProductPrice;
        }
    }
}
