using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using MyProject.Infrastructure;
using MyProject.Repository;
using NHibernate;

namespace MyProject.Presentation.MVC.PresentationLogic.Controler
{
    public static class IocContainer

    {
        private static IWindsorContainer _container;


        public static void Setup()

        {
            _container = new WindsorContainer().Install(FromAssembly.This());
            WindsorControllerFactory controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            _container.Register(Component.For(typeof(Repository<ProductCategory>)).ImplementedBy(typeof(IRepository<ProductCategory>)));


        }

    }
}