using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class OrderDetailsRow
    {
        public int OrderId { get; set; }

        public int UserName { get; set; }

        public int Product { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return string.Format("User: {0, -20} Order: {1, -20} Product: {2, -20} Quantity: {3, -20} ",
                UserName, OrderId,  Product, Quantity);
        }
    }
}
