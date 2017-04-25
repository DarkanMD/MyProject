using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace MyProject
{
    class OrderRepository : Repository<Order> 
    {
        public OrderRepository(ISession session) : base(session)
        {

        }

        public Order Get(long id)
        {
            return _session.QueryOver<Order>()
                .Where(o => o.OrderID == id)
                .SingleOrDefault<Order>();
        }
    }
}
