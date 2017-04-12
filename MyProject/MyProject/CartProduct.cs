using MyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;

namespace MyProject
{
    public class CartProduct
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
        public virtual int CartProductId { get; set; }
        public virtual AbstractProduct Product { get; set; }
        public virtual int Quantity { get; set; }
        public  decimal Subtotal
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

    public class CartProductMap : ClassMapping<CartProduct>
    {
        public CartProductMap()
        {
            Id(x=>x.CartProductId);
            Property(x=>x.Product);
            Property(x=>x.Quantity);
        }

    }
}
