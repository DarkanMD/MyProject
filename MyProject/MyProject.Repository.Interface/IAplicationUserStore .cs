using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Interface
{
    public interface IAplicationUserStore : IUserStore<User, int>, IQueryableUserStore<User, int>, IUserPasswordStore<User, int>, IUserRoleStore<User, int>
    {
    }
}
