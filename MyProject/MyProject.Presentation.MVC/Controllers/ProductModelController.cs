using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MyProject.Presentation.MVC.Models;
using MyProject.Repository.Interface;

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

        public ActionResult ViewProducts()
        {
            var products = _productRepository.GetPaged(1, 10, x => x.ProductPrice > 149, x => x.ProductName).Items;

            var result = Mapper.Map<IEnumerable<Product>,IEnumerable<ProductModel > >(products.Where(x=>x.ProductVisibility));
            return View(result);

        }
        public ActionResult Create()
        {

            ProductModel productModel = new ProductModel();
            productModel.ProductCategorys = _categorys;
            ViewBag.IrRanges = irRanges;
            ViewBag.Types = types;

            return View(productModel);
        }
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel productModel)
        {
            productModel.ProductCategorys = _categorys;
            ViewBag.IrRanges = irRanges;
            ViewBag.Types = types;
            Product product = new Product();
            if (ModelState.IsValid)
            {
                product = Mapper.Map<ProductModel, Product>(productModel);
            }
            _productRepository.Save(product);

            return View();
        }

        public ActionResult Edit(int id)
        {
            ProductModel productModel = new ProductModel();
            productModel.ProductCategorys = _categorys;
            ViewBag.IrRanges = irRanges;
            ViewBag.Types = types;
            Product product = _productRepository.Get(id);
            if (product != null)
            {
                productModel = Mapper.Map<Product, ProductModel>(product);
            }
            return View(productModel);
        }

        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel productModel)
        {
            productModel.ProductCategorys = _categorys;
            ViewBag.IrRanges = irRanges;
            ViewBag.Types = types;
            Product product = _productRepository.Get(productModel.Id);
            if (ModelState.IsValid)
            {
                product = Mapper.Map<ProductModel, Product>(productModel);

            }
            _productRepository.Save(product);

            return View(productModel);
        }
    }
}