using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;

namespace MyProject
{
    public class Cart
    {
        public virtual int UserID { get; set; }
        public virtual int CartID { get; set; }
        public virtual List<CartProduct> CartProducts { get; set; }

        decimal GrandTotal {
            get
            {
                decimal sum = 0;
                foreach (var item in CartProducts)
                {
                    sum = sum + item.Quantity * item.Product.ProductPrice;
                }
                return sum;
            }
        }

        public void AddCartProduct(CartProduct product)
        {
            if (!CartProducts.Contains(product)) { CartProducts.Add(product); }
            else
            {
                var index = CartProducts.FindIndex(x => x == product);
                CartProducts[index].Quantity += product.Quantity;
            }
        }

        public void RemoveCartProduct(CartProduct product)
        {
            CartProducts.Remove(product);
        }
    }

    public class CartMap : ClassMapping<Cart>
    {
        public CartMap()
        {
            Id(x=>x.CartID);
            Property(x=>x.UserID);
            ManyToOne(x=>x.CartProducts);
        }
    }
}
