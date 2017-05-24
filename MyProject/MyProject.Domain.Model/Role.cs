using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Model
{
    public class Role : Entity, IRole<int>
    {
        public virtual string Name { get; set; }

        public virtual ICollection<User> Users { get; protected set; }

        public Role()
        {
            this.Users = new List<User>();
        }
    }
}
