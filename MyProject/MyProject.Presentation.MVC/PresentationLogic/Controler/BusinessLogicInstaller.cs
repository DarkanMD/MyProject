using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MyProject.Infrastructure;
using MyProject.Repository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Presentation.MVC.PresentationLogic.Controler
{
    public class BusinessLogicInstaller : IWindsorInstaller

    {
        public void Install(IWindsorContainer container, IConfigurationStore store)

        {
            //  container.Register(Component.For(typeof(Repository<ProductCategory>)).ImplementedBy(typeof(IRepository<ProductCategory>)));
            //container.Register(Component.For(typeof(NHibernateProvider.GetSession())).ImplementedBy(typeof(ISession)));
        }
    }
}