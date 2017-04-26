using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;
using FluentNHibernate.Mapping;

namespace MyProject
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
