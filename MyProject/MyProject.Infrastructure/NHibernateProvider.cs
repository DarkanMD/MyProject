using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace MyProject.Infrastructure
{
    public class NHibernateProvider
    {
        private readonly string _connectionString;
        private ISessionFactory _sessionFactory;

        public NHibernateProvider(string connectionString )
        {
        //    _connectionString = connectionString;
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }

        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        private ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connectionString))
                .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(ProductMap).Assembly))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));
             // .ExposeConfiguration(CreateSchema);

            return configuration.BuildSessionFactory();
        }
        private static void CreateSchema(Configuration cfg)
        {
            var schemaExport = new SchemaExport(cfg);
            //  schemaExport.Execute(false, false, false);
            schemaExport.Drop(false, true);
            schemaExport.Create(false, true);
        }
    }
    //public class NHibernateProvider
    //{
    //    private static readonly string ConnectionStringName = System.Configuration.ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;

    //    private static ISessionFactory _sessionFactory;

    //    public ISession GetSession()
    //    {
    //        if (_sessionFactory == null)
    //        {
    //            _sessionFactory = CreateSessionFactory();
    //        }
    //        return _sessionFactory.OpenSession();
    //    }

    //    private static ISessionFactory CreateSessionFactory()
    //    {
    //        var configuration = Fluently.Configure()
    //            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionStringName))
    //            .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(ProductMap).Assembly))
    //           .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));
    //          //  .ExposeConfiguration(CreateSchema);

    //        return configuration.BuildSessionFactory();
    //    }

    //    private static void CreateSchema(Configuration cfg)
    //    {
    //        var schemaExport = new SchemaExport(cfg);
    //      //  schemaExport.Execute(false, false, false);
    //        schemaExport.Drop(false, true);
    //        schemaExport.Create(false, true);
    //    }
    //}
}
