using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNet.Identity;
using MyProject.Domain.Model.Mapping;
using NHibernate;
using System.Configuration;

namespace MyProject.Repository
 {
        public class DatabaseContext
        {
            private readonly ISessionFactory sessionFactory;
            public DatabaseContext()
            {
                var connectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
                sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                    .BuildSessionFactory();
            }
            public ISession MakeSession()
            {
                return sessionFactory.OpenSession();
            }
            public IUserStore<User, int> Users
            {
                get { return new IdentityStore(MakeSession()); }

            }
        }
    }