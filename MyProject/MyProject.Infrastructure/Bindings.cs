using NHibernate;
using Ninject.Modules;

namespace MyProject.Infrastructure
{
    public class Bindings : NinjectModule
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
