using System.Collections.Generic;
using MyProject.Domain.Model;

namespace MyProject
{
    public class User : Entity
    {
        public User()
        {
                Orders = new List<Order>();
        }

        public virtual IList<Order> Orders { get; set; }

        public virtual string UserName { get;  set; }

        public virtual string UserAddress { get;  set; }

        public virtual string UserEmailAddress { get;  set; }

        public virtual string UserPassword { get;  set; }

        public virtual byte UserRole { get;  set; }

        public virtual void AddOrder(Order order)
        {
            this.Orders.Add(order);
            order.User = this;
        }

    }
}
