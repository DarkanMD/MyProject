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
}
