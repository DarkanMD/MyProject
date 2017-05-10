
using FluentNHibernate.Mapping;
namespace MyProject

{
    public class OrderProductMap : ClassMap<OrderProduct>
    {
        public OrderProductMap()
        {
            Id(x => x.Id);
            References(x => x.Product);
            References(x => x.Order);
            Map(x => x.Quantity);
        }

    }
}