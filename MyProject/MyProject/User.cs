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
                Carts = new List<Cart>();
        }

        public User(string name, string addres, string email, string pass, byte role, List<Cart> carts) : this()
        {
            UserName = name;
            UserAddress = addres;
            UserEmailAddress = email;
            UserPassword = pass;
            UserRole = role;
            Carts = carts;
        }
        public virtual IList<Cart> Carts { get; set; }

        public virtual int UserID { get;  set; }

        public virtual string UserName { get;  set; }

        public virtual string UserAddress { get;  set; }

        public virtual string UserEmailAddress { get;  set; }

        public virtual string UserPassword { get;  set; }

        public virtual byte UserRole { get;  set; }

        public virtual void AddCart(Cart cart)
        {
            this.Carts.Add(cart);
            cart.User = this;
        }

    }

    class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.UserID);
            HasMany(x => x.Carts).KeyUpdate();
            Map(x => x.UserName);
            Map(x => x.UserAddress);
            Map(x => x.UserEmailAddress);
            Map(x => x.UserPassword);
            Map(x => x.UserRole);
        }
    }
}
