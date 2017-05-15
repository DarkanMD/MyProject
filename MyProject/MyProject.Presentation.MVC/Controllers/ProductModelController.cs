using System.Collections.Generic;
using System.Web.Mvc;
using MyProject.Presentation.MVC.Models;

namespace MyProject.Presentation.MVC.Controllers
{
    public class ProductModelController : Controller
    {
        private IRepository<ProductCategory> _rep;
        private IRepository<Product> _productRepository;
        private IList<ProductCategory> _categorys;
        IList<int> irRanges;
        IList<string> types;



        public ProductModelController(IRepository<ProductCategory> rep, IRepository<Product> productRep)
      {
            _rep = rep;
            _productRepository = productRep;
            _categorys = _rep.GetAll();
            irRanges = new List<int>() { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200 };
            types = new List<string>() { "External", "Internal" };
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateProductModel()
        {

            ProductModel productModel = new ProductModel();
            productModel.ProductCategorys = _categorys;
            ViewBag.IrRanges = irRanges;
            ViewBag.Types = types;

            return View(productModel);
        }
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult CreateProductModel(ProductModel productModel)
        {
            productModel.ProductCategorys = _categorys;
            ViewBag.IrRanges = irRanges;
            ViewBag.Types = types;
            Product product = new Product();
            if (ModelState.IsValid)
            {
                product.ProductName = productModel.ProductName;
                product.ProductDescription = productModel.ProductDescription;
                product.ProductIrRange = productModel.ProductIrRange;
                product.ProductCategory = _rep.Get(productModel.ProductCategory);
                product.ProductMatrixResolution = productModel.MatrixResolution;
                product.ProductPrice = productModel.ProductPrice;
                product.ProductStock = productModel.ProductStock;
                product.Type = productModel.Type;
                product.ProductVisibility = productModel.ProductVisibility;
            }
            _productRepository.Save(product);

            return View(productModel);
        }

        public ActionResult EditProductModel(int id)
        {
            ProductModel productModel = new ProductModel();
            productModel.ProductCategorys = _categorys;
            ViewBag.IrRanges = irRanges;
            ViewBag.Types = types;
            Product product = _productRepository.Get(id);
            if (product != null)
            {
                productModel.ProductCategory = product.ProductCategory.Id;
                productModel.MatrixResolution = product.ProductMatrixResolution;
                productModel.ProductDescription = product.ProductDescription;
                productModel.ProductIrRange = product.ProductIrRange;
                productModel.ProductName = product.ProductName;
                productModel.ProductPrice = product.ProductPrice;
                productModel.ProductStock = product.ProductStock;
                productModel.ProductVisibility = product.ProductVisibility;
                productModel.Type = product.Type;
                productModel.Id = product.Id;
            }
            return View(productModel);
        }

        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public ActionResult EditProductModel(ProductModel productModel)
        {
            productModel.ProductCategorys = _categorys;
            ViewBag.IrRanges = irRanges;
            ViewBag.Types = types;
            Product product = _productRepository.Get(productModel.Id);
            if (ModelState.IsValid)
            {
                product.ProductName = productModel.ProductName;
                product.ProductDescription = productModel.ProductDescription;
                product.ProductIrRange = productModel.ProductIrRange;
                product.ProductCategory = _rep.Get(productModel.ProductCategory);
                product.ProductMatrixResolution = productModel.MatrixResolution;
                product.ProductPrice = productModel.ProductPrice;
                product.ProductStock = productModel.ProductStock;
                product.Type = productModel.Type;
                product.ProductVisibility = productModel.ProductVisibility;
               
            }
            _productRepository.Save(product);

            return View(productModel);
        }
    }
}