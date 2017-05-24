using MyProject.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace MyProject.Repository
{
    public class AplicationUserManager : UserManager<User, int>
    {
        public AplicationUserManager(IAplicationUserStore store) : base(store)
        {
        }
    }
}
