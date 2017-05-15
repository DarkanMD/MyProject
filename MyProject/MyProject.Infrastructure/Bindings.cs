using MyProject;
using MyProject.Repository;
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
            get { return instance; }
        }

        public override void Load()
        {
            //var nhibernate = new NHibernateProvider();
            //Bind<ISession>().ToMethod(x => nhibernate.GetSession());
            //Bind < typeof(IRepository<ProductCategory>()).To(Repository<ProductCategory>());
            //Bind(typeof(IRepository<ProductCategory>)).To(typeof(Repository<ProductCategory>));
        }
    }
}