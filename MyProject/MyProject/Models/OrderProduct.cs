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
    public class OrderProduct : Entity
    {
        public OrderProduct()
        {

        }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public virtual int Quantity { get; set; }

        public virtual decimal Subtotal
        {
            get { return Quantity * Product.ProductPrice; }
        }
    }

    public class OrderProductMap : ClassMap<OrderProduct>
    {
        public OrderProductMap()
        {
            Id(x => x.Id);
            References(x => x.Product);
            References(x => x.Order);
            Map(x => x.Quantity);
        }

    }
}
