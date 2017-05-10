using FluentNHibernate.Mapping;
using MyProject;

namespace MyProject
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id);
            References(x => x.User);
            HasMany(x => x.OrderProducts).Inverse().Cascade.AllDeleteOrphan();
        }
    }
}