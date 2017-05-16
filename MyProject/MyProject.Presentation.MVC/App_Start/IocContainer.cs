using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using MyProject.Infrastructure;
using MyProject.Repository;
using MyProject.Repository.Interface;
using NHibernate;

namespace MyProject.Presentation.MVC
{
    public static class IocContainer

    {
        private static IWindsorContainer _container;


        public static void Setup()

        {
            NHibernateProvider provider = new NHibernateProvider();
            _container = new WindsorContainer().Install(FromAssembly.This());
            WindsorControllerFactory controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            _container.Register(Component.For(typeof(IRepository<Order>)).ImplementedBy(typeof(OrderRepository)));
            _container.Register(Component.For(typeof(IRepository<ProductCategory>)).ImplementedBy(typeof(Repository<ProductCategory>)));
            _container.Register(Component.For(typeof(IRepository<Product>)).ImplementedBy(typeof(ProductRepository)));
            // _container.Register(Component.For<ISessionFactory>().Instance(provider.SessionFactory).LifestyleSingleton());
            //_container.Register(Component.For<ISession>().UsingFactory((ISessionFactory sessionFactory) => sessionFactory.OpenSession()).LifestylePerWebRequest());
            _container.Register(Component.For<ISession>().Instance(provider.SessionFactory.OpenSession()));
        }

    }
}