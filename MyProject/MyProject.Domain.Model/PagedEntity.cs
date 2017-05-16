using System.Collections.Generic;
using MyProject.Domain.Model;


namespace MyProject.Domain.Model
{
    public class PagedEntity<T> where T: Entity
    {
        public PagedEntity( )
        {

        }
        public IEnumerable<T> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int ItemCount { get; set; }
        public int Pages => (ItemCount / PageSize)%2 ==0 ? ItemCount / PageSize: ItemCount / PageSize+1;
    }
}
