using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MyProject.Presentation.MVC.Models;
using MyProject.Repository.Interface;
using Newtonsoft.Json;
using NHibernate;
using Newtonsoft.Json.Serialization;
using System;

namespace MyProject.Presentation.MVC.Controllers
{
    public class ProductModelController : Controller
    {
        //private IRepository<ProductCategory> _rep;
        private IRepository<Product> _productRepository;
        private IList<ProductCategory> _categorys;
        IList<int> irRanges;
        IList<string> types;
        private IList<int> matrixResolutions;



        public ProductModelController(IRepository<Product> productRep)
      {
            //_rep = rep;
            _productRepository = productRep;
            _categorys = new List<ProductCategory>() {new ProductCategory() {CategoryName = "Dome",Id = 1}, new ProductCategory() { CategoryName = "Bulet", Id = 2 },
                new ProductCategory() { CategoryName = "PTZ", Id = 3 }, new ProductCategory() { CategoryName = "SPY", Id = 4 } };
            irRanges = new List<int>() { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200 };
            matrixResolutions = new List<int>() {1,2,3,4,5,6,7,8,9,10};
            types = new List<string>() { "External", "Internal" };
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewProducts()
        {
            var products = _productRepository.GetPaged(1, 10, x => x.ProductPrice > 0, x => x.ProductName).Items;

            var result = Mapper.Map<IEnumerable<Product>,IEnumerable<ProductModel > >(products.Where(x=>x.ProductVisibility));
            return View(result);

        }
        public ActionResult Create()
        {

            ProductModel productModel = new ProductModel();
            productModel.ProductCategorys = _categorys;
            ViewBag.IrRanges = irRanges;
            ViewBag.Types = types;
            ViewBag.MatrixResolutions = matrixResolutions;

            return View(productModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel productModel)
        {
            productModel.ProductCategorys = _categorys;
            ViewBag.IrRanges = irRanges;
            ViewBag.Types = types;
            ViewBag.MatrixResolutions = matrixResolutions;
            Product product = new Product();
            if (ModelState.IsValid)
            {
                product = Mapper.Map<ProductModel, Product>(productModel);
            }
            _productRepository.Save(product);

            return RedirectToAction("ViewProducts");
        }

        public ActionResult Edit(int id)
        {
            ProductModel productModel = new ProductModel();
            ViewBag.IrRanges = irRanges;
            ViewBag.Types = types;
            ViewBag.MatrixResolutions = matrixResolutions;
            Product product = _productRepository.Get(id);
            if (product != null)
            {
                productModel = Mapper.Map<Product, ProductModel>(product);
            }
            productModel.ProductCategorys = _categorys;
            return View(productModel);
        }

        [HttpPost]

        public ActionResult Edit(ProductModel productModel)
        {
            productModel.ProductCategorys = _categorys;
            ViewBag.IrRanges = irRanges;
           ViewBag.Types = types;
            ViewBag.MatrixResolutions = matrixResolutions;
            if (ModelState.IsValid)
            {
                var product = _productRepository.Get(productModel.Id);
                Mapper.Map(productModel, product);
                _productRepository.Save(product);
            }
            return  RedirectToAction( "ViewProducts");
        }

        public ActionResult Delete(int id)
        {
            ProductModel productModel = new ProductModel();
            productModel.ProductCategorys = _categorys;
            ViewBag.IrRanges = irRanges;
            ViewBag.Types = types;
            ViewBag.MatrixResolutions = matrixResolutions;
            Product product = _productRepository.Get(id);
            if (product != null)
            {
                productModel = Mapper.Map<Product, ProductModel>(product);
            }
            return View(productModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductModel productModel)
        {

            if (productModel != null)
            {
                var product =_productRepository.Get(productModel.Id);
                _productRepository.Delete(product);
            }
            return  RedirectToAction( "ViewProducts"); ;
        }
     
        public JsonResult GimmeData()
        {
            var data = JsonConvert.SerializeObject(_productRepository.Get(5),
                new JsonSerializerSettings()
                {
                    ContractResolver = new NHibernateContractResolver(),
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore

                });
            return Json(data,JsonRequestBehavior.AllowGet);
        } 
    }
    public class NHibernateContractResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            if (typeof(NHibernate.Proxy.INHibernateProxy).IsAssignableFrom(objectType))
                return base.CreateContract(objectType.BaseType);
            else
                return base.CreateContract(objectType);
        }
    }
}