using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Presentation.MVC.Models
{
    public class ProductJsonModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Type { get; set; }
        public int ProductMatrixResolution { get; set; }
        public int ProductIrRange { get; set; }
        public string ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
    }
}