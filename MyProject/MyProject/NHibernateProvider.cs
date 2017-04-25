using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public static class NHibernateProvider
    {
        private static readonly string ConnectionStringName = System.Configuration.ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;

        private static ISessionFactory _sessionFactory;

        public static ISession GetSession()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = CreateSessionFactory();
            }
            return _sessionFactory.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionStringName))
                .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(ProductMap).Assembly))
               .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));
                //.ExposeConfiguration(CreateSchema);

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
}
