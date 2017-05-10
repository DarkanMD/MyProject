using FluentNHibernate.Mapping;
namespace MyProject
{
    class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            HasMany(x => x.Orders).Inverse().Cascade.AllDeleteOrphan();
            Map(x => x.UserName);
            Map(x => x.UserAddress);
            Map(x => x.UserEmailAddress);
            Map(x => x.UserPassword);
            Map(x => x.UserRole);
        }
    }
}