using MyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    class CartProduct
    {
        //ctor for read
        public CartProduct(int id, AbstractProduct product, int quantity)
        {
            CartProductID = id;
            Product = product;
            Quantity = quantity;
        }
        //ctor for create
        public CartProduct(AbstractProduct product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public int CartProductID { get; set; }
        public AbstractProduct Product { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal
        {
            get
            {
                return Quantity * Product.ProductPrice;
            }
        }

        public override bool Equals(object obj)
        {
            var product = (CartProduct)obj;
            return this.Product.ProductID == product.Product.ProductID ? true : false;
        }
    }
}
