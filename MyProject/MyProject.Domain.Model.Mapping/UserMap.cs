using FluentNHibernate.Mapping;

namespace MyProject.Domain.Model.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.UserName);
            Map(x => x.PasswordHash);
        }
    }
}