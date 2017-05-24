using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Interface
{
    public interface IAplicationRoleStore : IRoleStore<Role, int>, IQueryableRoleStore<Role, int>
    {
    }
}
