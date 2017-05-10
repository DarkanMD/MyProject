using MyProject;
using System.Collections.Generic;

namespace MyProject.Presentation.MVC.Models
{
    public class ProductViewModel
    {
        public  int Id { get; set; }

        public  string ProductName { get; set; }

        public ProductCategory ProductCategory { get; set; }
        public  IEnumerable <ProductCategory> ProductCategorys { get;set;}

        public  int ProductIrRange { get; set; }

        public  int Type { get; set; }

        public  decimal ProductPrice { get; set; }

        public  int ProductStock { get; set; }

        public  string ProductDescription { get; set; }

        public  bool ProductVisibility { get; set; }
    }
}