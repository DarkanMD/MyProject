using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    class Cart
    {
        int UserID { get; set; }
        int CartID { get; set; }
        List<CartProduct> CartProducts { get; set; }

        decimal Total {
            get
            {
                decimal sum = 0;
                foreach (var item in CartProducts)
                {
                    sum=sum+item.Quantity*item.Produc
                }
            }
        }

        public void AddCartProduct(CartProduct product)
        {
            CartProducts.Add(product);
        }

        public void RemoveCartProduct(CartProduct product)
        {
            CartProducts.Remove(product);
        }
    }
}
