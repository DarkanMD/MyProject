using Castle.Windsor;
using Castle.Windsor.Installer;
using MyProject.Presentation.MVC;
using MyProject.Presentation.MVC.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyProject.Presentation.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var ioc = new IocContainer("SQL");
            var container = new WindsorContainer().Install(FromAssembly.This());
            ioc.Setup(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
           // IocContainer.Setup();
            MappingConfig.RegisterMaps();

        }
    }
}
