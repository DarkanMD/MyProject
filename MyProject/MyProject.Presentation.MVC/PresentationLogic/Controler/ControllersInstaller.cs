using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Castle.MicroKernel.Registration.AllTypes;

namespace MyProject.Presentation.MVC.PresentationLogic.Controler
{
    public class ControllersInstaller : IWindsorInstaller

    {
        public void Install(IWindsorContainer container, IConfigurationStore store)

        {
            container.Register(FromThisAssembly()
                .Pick()
                .If(t => t.Name.EndsWith("Controller"))
                .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                .LifestylePerWebRequest());
        }
    }
}