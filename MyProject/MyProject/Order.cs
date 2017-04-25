using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using FluentNHibernate.Mapping;

namespace MyProject
{
    public class Order
    {
        public Order()
        {
            OrderProducts = new List<OrderProduct>();
        }

        public Order(List<OrderProduct> orderProduct)
        {
            OrderProducts = orderProduct;
        }
        public virtual int OrderID { get; set; }
        public virtual User User { get; set; }

        public virtual IList<OrderProduct> OrderProducts { get; set; }

        public virtual decimal GrandTotal {
            get
            {
                decimal sum = 0;
                foreach (var item in OrderProducts)
                {
                    sum = sum + item.Subtotal;
                }
                return sum;
            }
        }

        public virtual void AddOrderProduct(OrderProduct product)
        {
            this.OrderProducts.Add(product);
            product.Order = this;
        }
    }

    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.OrderID);
            References(x => x.User);
            HasMany(x => x.OrderProducts).Inverse().Cascade.AllDeleteOrphan();
        }
    }
}
