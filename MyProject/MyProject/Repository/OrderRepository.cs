using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace MyProject
{
    public class OrderRepository : Repository<Order> 
    {
        public IList<Order> GetAll(int id)
        {
            return _session.QueryOver<Order>().List();
        }

        public IList<int> GetAllOrderIds()
        {
            return _session.QueryOver<Order>().Select(x=>x.Id).List<int>();
        }

        public User GetUserByOrderId(int id)
        {
            return _session.QueryOver<Order>()
                .Where(x=>x.Id ==id)
                .Select(x => x.User).SingleOrDefault<User>();
        }

        public IList<OrderProduct> AllCustomerOrderProductsByUserId(int id)
        {

            return _session.QueryOver<OrderProduct>()
                .Where(x=>x.Order.User.Id==id)
                .Select(x=>x)
                .List<OrderProduct>();
        }
    }
}
