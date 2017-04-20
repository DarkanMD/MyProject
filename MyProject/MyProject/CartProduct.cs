using MyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using FluentNHibernate.Mapping;

namespace MyProject
{
    public class CartProduct
    {
        //ctor for read
        public CartProduct()
        {
                    
        }
        public CartProduct(int id, Product product, int quantity)
        {
            CartProductId = id;
            Product = product;
            Quantity = quantity;
        }
        //ctor for create
        public CartProduct(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public virtual int CartProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal Subtotal
        {
            get
            {
                return Quantity * Product.ProductPrice;
            }
        }

        public override bool Equals(object obj)
        {
            var product = (CartProduct)obj;
            return this.Product.ProductId == product.Product.ProductId ? true : false;
        }
    }

    public class CartProductMap : ClassMap<CartProduct>
    {
        public CartProductMap()
        {
            Id(x => x.CartProductId);
            References(x => x.Product);
            Map(x => x.Quantity);
        }

    }
}
