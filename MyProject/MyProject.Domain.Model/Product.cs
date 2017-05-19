using MyProject.Domain.Model;

namespace MyProject
   {
       public enum CameraType {External, Internal }
    public class Product : Entity
    {

        public Product()
        {
        }
        public virtual string ProductName { get; set; }
        public virtual string ProductDescription { get; set; }
        public virtual CameraType Type { get; set; }
        public virtual int ProductMatrixResolution { get; set; }
        public virtual int ProductIrRange { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual decimal ProductPrice { get; set; }
        public virtual int ProductStock { get; set; }

        public virtual bool ProductVisibility { get; set; }

        public override string ToString()
        {
            return $"{Id} {ProductName} {ProductCategory.CategoryName} {ProductIrRange} {ProductMatrixResolution} {ProductPrice:c} {ProductStock} {ProductDescription} {ProductVisibility}";
        }
    }
   }
