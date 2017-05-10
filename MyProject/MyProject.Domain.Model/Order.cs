using System.Collections.Generic;
using MyProject.Domain.Model;

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
}
