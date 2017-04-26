using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using FluentNHibernate.Mapping;

namespace MyProject
{
    public class Order : Entity
    {
        public Order()
        {
            OrderProducts = new List<OrderProduct>();
        }

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

        public virtual void AddOrderProduct(OrderProduct orderProduct)
        {
            this.OrderProducts.Add(orderProduct);
            orderProduct.Order = this;
        }
    }

    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id);
            References(x => x.User);
            HasMany(x => x.OrderProducts).Inverse().Cascade.AllDeleteOrphan();
        }
    }
}
