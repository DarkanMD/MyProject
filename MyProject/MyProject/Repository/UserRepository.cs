using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using NHibernate.Hql.Ast.ANTLR.Tree;

namespace MyProject.Repository
{
    class UserRepository  :Repository<User>
    {
        public IList<User> GetUsersWithOrders()
        {
            return _session.QueryOver<User>()
                .OrderBy(x=>x.Orders.Count).Desc
                .JoinQueryOver(x => x.Orders)
                .TransformUsing(Transformers.DistinctRootEntity)
                .List<User>();
        }

        public IList<User> GetAllUsers()
        {
            return _session.QueryOver<User>()
                .List<User>();
        }



    }
}
