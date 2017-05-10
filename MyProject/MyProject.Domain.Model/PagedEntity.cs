using System.Collections.Generic;

namespace MyProject.Models
{
    public class PagedEntity<T> where T: class
    {
        IEnumerable<T> _items;
        int _totalCount;

        public PagedEntity(IEnumerable<T> items, int totalCount)
        {
            _items = items;
            _totalCount = totalCount;
        }

        public IEnumerable<T> Items { get { return _items; } }
        public int TotalCount { get { return _totalCount; } }
    }
}
