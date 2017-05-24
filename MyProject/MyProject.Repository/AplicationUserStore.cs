using MyProject.Domain.Model;
using MyProject.Repository.Interface;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using System.Linq.Expressions;

namespace MyProject.Repository
{
    public class AplicationUserStore : Repository<User>, IAplicationUserStore
    {
        public AplicationUserStore(ISession session,ITransaction transaction) : base(session,transaction)
        {
        }

        public IQueryable<User> Users => _session.Query<User>();

        public Task CreateAsync(User user)
        {
            return Task.Run(() => _session.Save(user));
        }

        public Task DeleteAsync(User user)
        {
            return Task.Run(() => _session.Delete(user));
        }

        public Task<User> FindByIdAsync(int userId)
        {
            return Task.Run(() => _session.Get<User>(userId));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task.Run(() =>
            {
                return _session.QueryOver<User>().Where(user => user.UserName == userName).SingleOrDefault<User>();
            });
        }

        public Task UpdateAsync(User user)
        {
            return Task.Run(() => _session.Update(user));
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            return Task.Run(() => user.PasswordHash = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.Run(() => user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.Run(() => user.PasswordHash != null);
        }

        public void Dispose()
        {

        }

        public Task AddToRoleAsync(User user, string roleName)
        {
            return Task.Run(() =>
            {
                if ((object)user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                if (string.IsNullOrWhiteSpace(roleName))
                {
                    throw new ArgumentException("Name");
                }

                Role identityRole = Queryable.SingleOrDefault<Role>(this._session.Query<Role>(), (Expression<Func<Role, bool>>)(r => r.Name.ToUpper() == roleName.ToUpper()));
                if (identityRole == null)
                {
                    throw new InvalidOperationException();
                }
                user.Roles.Add(identityRole);
            });
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            return Task.Run(() =>
            {
                if ((object)user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                if (string.IsNullOrWhiteSpace(roleName))
                {
                    throw new ArgumentException(nameof(roleName));
                }

                Role identityUserRole = Enumerable.FirstOrDefault<Role>(Enumerable.Where<Role>((IEnumerable<Role>)user.Roles, (Func<Role, bool>)(r => r.Name.ToUpper() == roleName.ToUpper())));
                if (identityUserRole != null)
                {
                    user.Roles.Remove(identityUserRole);
                }
            });
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            return Task.Run(() =>
            {
                if ((object)user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                else
                {
                    return Task.FromResult<IList<string>>((IList<string>)Enumerable.ToList<string>(Enumerable.Select<Role, string>((IEnumerable<Role>)user.Roles, (Func<Role, string>)(u => u.Name))));
                }
            });
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            return Task.Run(() =>
            {
                if ((object)user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                if (string.IsNullOrWhiteSpace(roleName))
                {
                    throw new ArgumentException(nameof(roleName));
                }
                else
                {
                    return Task.FromResult<bool>(Enumerable.Any<Role>((IEnumerable<Role>)user.Roles, (Func<Role, bool>)(r => r.Name.ToUpper() == roleName.ToUpper())));
                }
            });
        }
    }
}
