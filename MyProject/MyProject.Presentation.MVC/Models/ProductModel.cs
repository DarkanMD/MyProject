using MyProject;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Presentation.MVC.Models
{
    public class ProductModel:Product
    {
        public  int Id { get; set; }
        [DisplayName("Product Name")]
        [MinLength(10)]
        [MaxLength(30)]
        public  string ProductName { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; }

        [DisplayName("Matrix Resolution")]
        public int ProductMatrixResolution { get; set; }

        [DisplayName("Category")]
        public int ProductCategory { get; set; }
        public  IEnumerable <ProductCategory> ProductCategorys { get;set;}

        [DisplayName("Price")]

        public decimal ProductPrice { get; set; }

        [DisplayName("Ir Range (m)")]
        public  int ProductIrRange { get; set; }

        public  CameraType Type { get; set; }

        [DisplayName("Quantity")]

        public  int ProductStock { get; set; }

        [DisplayName("Product Visible")]
        [Required]
        public  bool ProductVisibility { get; set; }
    }
}