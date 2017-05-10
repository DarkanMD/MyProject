using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using MyProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProject.Repository;
using NHibernate;
//using NHibernate.Mapping;

namespace MyProject.Presentation.MVC.PresentationLogic.Controler
{
    public class IoC
    {
        private readonly string _connectionString;

        public IoC(string connectionString)
        {
           // _connectionString = connectionString;
        }

        public void RegisterAll(IKernel kernel)
        {

            //Registering Services
            //Registering Repositories
            kernel.Register(Component.For(typeof(IRepository<ProductCategory>))
                .ImplementedBy(typeof(Repository<ProductCategory>)));
            //    kernel.Register(Component.For(typeof(IProductRepository)).ImplementedBy(typeof(ProductRepository)));
            //   kernel.Register(Castle.MicroKernel.Registration.Component.For(typeof(IUserRepository)).ImplementedBy(typeof(UserRepository)));


            kernel.Register(
                Component.For<ISession>().Instance(NHibernateProvider.GetSession()).LifestylePerWebRequest());
            kernel.Register(Component.For<ITransaction>()
                .Instance(NHibernateProvider.GetSession().BeginTransaction())
                .LifestylePerWebRequest());
        }
    }
}