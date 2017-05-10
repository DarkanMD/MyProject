using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
public class PagedResult<TEntity>
{
    public PagedResult(IEnumerable<TEntity> items, int totalCount)
    {
        Items = items;
        TotalCount = totalCount;
    }
    
    public IEnumerable<TEntity> Items { get; }
    public int TotalCount { get; }
}
}
