using NHibernate;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    class Bindings : NinjectModule
    {
        private static readonly Bindings instance = new Bindings();

        static Bindings()
        {
        }

        private Bindings()
        {
        }

        public static Bindings Instance
        {
            get
            {
                return instance;
            }
        }

        public override void Load()
        {
            Bind<ISession>().ToMethod(x => NHibernateProvider.GetSession());
        }
    }
}
