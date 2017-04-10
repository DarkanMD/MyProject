using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    class CartProduct
    {
        public CartProduct(int id)
        {
            CartProductID = id;
        }
        public int CartProductID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public override bool Equals(object obj)
        {
            var product = (CartProduct)obj;
            return this.ProductID == product.ProductID ? true : false;
        }
    }
}
