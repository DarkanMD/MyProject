
namespace MyProject.Domain.Model
{
    public abstract class Entity
    {
        public virtual int Id { get; set; }
    }

    //public class EntityMap : ClassMap<Entity>
    //{
    //    public EntityMap()
    //    {
    //         //   UseUnionSubclassForInheritanceMapping();
    //    }
    //}
}
