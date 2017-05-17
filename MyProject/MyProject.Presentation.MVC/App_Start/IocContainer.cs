using System.Web.Mvc;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using MyProject.Infrastructure;
using MyProject.Repository;
using MyProject.Repository.Interface;
using NHibernate;

namespace MyProject.Presentation.MVC
{
    public class IocContainer

    {
        private IKernel _kernel;
        private string _connectionString;

        public IocContainer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Setup(IKernel kernel)
        {
            _kernel = kernel;
            NHibernateProvider provider = new NHibernateProvider(_connectionString);
            //_container = new WindsorContainer().Install(FromAssembly.This());
            _kernel.Register(Component.For<ISessionFactory>().Instance(provider.SessionFactory).LifestyleSingleton());
            _kernel.Register(Component.For<ISession>().UsingFactory((ISessionFactory sessionFactory) => sessionFactory.OpenSession()).LifestylePerWebRequest());
            _kernel.Register(Component.For<ITransaction>().UsingFactory((ISession session) => session.BeginTransaction()).LifestylePerWebRequest());

            //_container.Register(Component.For<ISessionFactory>().Instance(provider.SessionFactory).LifestyleSingleton());
            //_container.Register(Component.For<ISession>().UsingFactory((ISessionFactory sessionFactory) => sessionFactory.OpenSession()).LifestylePerWebRequest());
            //_container.Register(Component.For<ITransaction>().UsingFactory((ISession session) => session.BeginTransaction()).LifestylePerWebRequest());
            //    _container.Register(Component.For(typeof(IRepository<Order>)).ImplementedBy(typeof(OrderRepository)));
            _kernel.Register(Component.For(typeof(IRepository<ProductCategory>)).ImplementedBy(typeof(Repository<ProductCategory>)).LifestylePerWebRequest());
            _kernel.Register(Component.For(typeof(IRepository<Product>)).ImplementedBy(typeof(Repository<Product>)).LifestylePerWebRequest());

            //_container.Register(Component.For<ISession>().Instance(provider.SessionFactory.OpenSession()));
        }

    }
}