using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using FluentNHibernate.Mapping;

namespace MyProject
{
    public class Cart
    {
        public Cart()
        {
                
        }

        public Cart(List<CartProduct> cartproducts)
        {
            CartProducts = cartproducts;
        }
        public virtual int CartID { get; set; }
        public virtual User User { get; set; }

        public virtual IList<CartProduct> CartProducts { get; set; }

        public virtual decimal GrandTotal {
            get
            {
                decimal sum = 0;
                foreach (var item in CartProducts)
                {
                    sum = sum + item.Subtotal;
                }
                return sum;
            }
        }

        //public virtual void AddCartProduct(CartProduct product)
        //{
        //    if (!CartProducts.Contains(product)) { CartProducts.Add(product); }
        //    else
        //    {
        //        var index = CartProducts.FindIndex(x => x == product);
        //        CartProducts[index].Quantity += product.Quantity;
        //    }
        //}

        public virtual void RemoveCartProduct(CartProduct product)
        {
            CartProducts.Remove(product);
        }
    }

    public class CartMap : ClassMap<Cart>
    {
        public CartMap()
        {
            Id(x => x.CartID);
            References(x => x.User);
            HasMany(x => x.CartProducts);
        }
    }
}
