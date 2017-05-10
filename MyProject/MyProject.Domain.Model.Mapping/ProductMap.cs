
using FluentNHibernate.Mapping;
namespace MyProject
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.ProductName);
            Map(x => x.ProductIrRange);
            Map(x => x.Type);
            References(x => x.ProductCategory);
            Map(x => x.ProductPrice);
            Map(x => x.ProductStock);
            Map(x => x.ProductDescription);
            Map(x => x.ProductVisibility);
        }
    }
}