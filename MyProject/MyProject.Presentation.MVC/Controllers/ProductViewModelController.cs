using System.Collections.Generic;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Web.Mvc;
using MyProject.Presentation.MVC.Models;
using MyProject;
using MyProject.Repository;

namespace MyProject.Presentation.MVC.Controllers
{
    public class ProductViewModelController : Controller
    {
        private static readonly string ConnectionStringName = System.Configuration.ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
        private IRepository<ProductCategory> _rep;
        private static ISessionFactory _sessionFactory;

        private IEnumerable<ProductCategory> x;
        public static ISession GetSession()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = CreateSessionFactory();
            }
            return _sessionFactory.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionStringName))
                .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(ProductMap).Assembly))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));
            //  .ExposeConfiguration(CreateSchema);

            return configuration.BuildSessionFactory();
        }

        public ProductViewModelController()
        {
          

        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateProductViewModel()
        {
            var session = GetSession();
            var test = session.QueryOver<ProductCategory>().List<ProductCategory>();
            ProductViewModel pr = new ProductViewModel();
            pr.ProductCategorys = test;

            return View(pr);
        }
    }
}