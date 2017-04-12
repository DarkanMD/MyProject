using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public abstract class AbstractProduct
    {
        public virtual int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string ProductCategory { get; set; }
        public virtual decimal ProductPrice { get; set; }
        public virtual int ProductStock { get; set; }
        public virtual string ProductDescription { get; set; }
        public virtual bool ProductVisibility { get; set; }
    }
}
