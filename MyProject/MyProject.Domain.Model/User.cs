using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using MyProject.Domain.Model;
using FluentNHibernate.Mapping;

namespace MyProject
{
        public class User : Entity, IUser<int>
        {
            public virtual string UserName { get; set; }
            public virtual string PasswordHash { get; set; }
           // public virtual string Email { get; set; }
            //public virtual ICollection<Role> Roles { get; protected set; }

            //public ICollection<Key> Keys { get; set; }
          //  public virtual ICollection<Order> Orders { get; set; }
            //public virtual Profile Profile { get; set; }

            //public User()
            //{
            //    this.Roles = new List<Role>();
            //}
        }
        //public User()
        //{
        //        Orders = new List<Order>();
        //}

        //public virtual IList<Order> Orders { get; set; }

        //public virtual string UserName { get;  set; }

        //public virtual string UserAddress { get;  set; }

        //public virtual string UserEmailAddress { get;  set; }

        //public virtual string UserPassword { get;  set; }

        //public virtual byte UserRole { get;  set; }

        //public virtual void AddOrder(Order order)
        //{
        //    this.Orders.Add(order);
        //    order.User = this;
        //}

    

}
