using MyProject.Domain.Model;

namespace MyProject
{
    public class OrderProduct : Entity
    {
        public OrderProduct()
        {

        }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public virtual int Quantity { get; set; }

        public virtual decimal Subtotal
        {
            get { return Quantity * Product.ProductPrice; }
        }
    }
}
