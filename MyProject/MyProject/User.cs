using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace MyProject
{
    public class User
    {
        public User()
        {
                Orders = new List<Order>();
        }

        public User(string name, string addres, string email, string pass, byte role, List<Order> orders) : this()
        {
            UserName = name;
            UserAddress = addres;
            UserEmailAddress = email;
            UserPassword = pass;
            UserRole = role;
            Orders = orders;
        }
        public virtual IList<Order> Orders { get; set; }

        public virtual int UserID { get;  set; }

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

    class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.UserID);
            HasMany(x => x.Orders).Inverse().Cascade.AllDeleteOrphan();
            Map(x => x.UserName);
            Map(x => x.UserAddress);
            Map(x => x.UserEmailAddress);
            Map(x => x.UserPassword);
            Map(x => x.UserRole);
        }
    }
}
