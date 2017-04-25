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
    public class OrderProduct
    {
        //ctor for read
        public OrderProduct()
        {
                    
        }
        public OrderProduct(int id, Product product, int quantity)
        {
            OrderProductId = id;
            Product = product;
            Quantity = quantity;
        }
        //ctor for create
        public OrderProduct(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public virtual int OrderProductId { get; set; }
        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }
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
            var product = (OrderProduct)obj;
            return this.Product.ProductId == product.Product.ProductId ? true : false;
        }
    }

    public class OrderProductMap : ClassMap<OrderProduct>
    {
        public OrderProductMap()
        {
            Id(x => x.OrderProductId);
            References(x => x.Product);
            Map(x => x.Quantity);
        }

    }
}
