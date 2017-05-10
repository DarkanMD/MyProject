using System.Collections.Generic;
using MyProject.Domain.Model.Rows;
using MyProject.Models;
using NHibernate.Transform;

namespace MyProject.Repository
{
    public class OrderRepository : Repository<Order> 
    {

        public int UserIdByOrderId(int id)
        {
            return _session.QueryOver<Order>()
                .Where(x => x.Id == id)
                .Select(x => x.User.Id)
                .SingleOrDefault<int>();
        }
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

        public IList<OrderDetailsRow> GetOrderDetailsRows(int id)
        {
            Order order = null;
            User user = null;
            OrderProduct orderProduct = null;
            OrderDetailsRow orderDetailsRow= null;

            return _session.QueryOver(() => user)
                .Where(()=>user.Id==id)
                .Left.JoinAlias(() => user.Orders, () => order)
                .Left.JoinAlias(() => order.OrderProducts, () => orderProduct)
                .SelectList(list => list
                    .Select(() => order.Id).WithAlias(() => orderDetailsRow.OrderId)
                    .Select(() => user.Id).WithAlias(() => orderDetailsRow.UserName)
                    .Select(() => orderProduct.Id).WithAlias(() => orderDetailsRow.Product)
                    .Select(() => orderProduct.Quantity).WithAlias(() => orderDetailsRow.Quantity))
                .TransformUsing(Transformers.AliasToBean<OrderDetailsRow>())
                .List<OrderDetailsRow>();

        }

        public IList<OrderProduct> AllCustomerOrderProductsByUserId(int id)
        {
            User user = null;
            Order order = null;
            OrderProduct op = null;

            return _session.QueryOver(()=>op)
                .JoinAlias(()=>op.Order, ()=>order)
                .JoinAlias(()=>order.User, ()=>user)
                .Where(()=>user.Id==id)
                .List<OrderProduct>();
        }
    }
}
