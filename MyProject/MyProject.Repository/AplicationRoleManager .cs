using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MyProject.Domain.Model;
using MyProject.Repository.Interface;

namespace MyProject.Repository
{
    public class AplicationRoleManager : RoleManager<Role, int>
    {
        public AplicationRoleManager(IAplicationRoleStore store) : base(store)
        {
        }
    }
}
