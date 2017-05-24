using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Domain.Model;
using NHibernate;
using NHibernate.Linq;
using MyProject.Repository.Interface;

namespace MyProject.Repository
{
    public class AplicationRoleStore : Repository<Role>, IAplicationRoleStore
    {
        public AplicationRoleStore(ISession session,ITransaction transaction) : base(session, transaction)
        {
        }

        public IQueryable<Role> Roles => _session.Query<Role>();

        public Task CreateAsync(Role role)
        {
            return Task.Run(() => _session.Save(role));
        }

        public Task DeleteAsync(Role role)
        {
            return Task.Run(() => _session.Delete(role));
        }

        public Task<Role> FindByIdAsync(int roleId)
        {
            return Task.Run(() => _session.Get<Role>(roleId));
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return Task.Run(() =>
            {
                return _session.QueryOver<Role>().Where(role => role.Name == roleName).SingleOrDefault<Role>();
            });
        }

        public Task UpdateAsync(Role role)
        {
            return Task.Run(() => _session.Update(role));
        }

        public void Dispose()
        {

        }
    }
}
