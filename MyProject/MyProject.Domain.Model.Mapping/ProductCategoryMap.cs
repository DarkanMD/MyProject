using FluentNHibernate.Mapping;
namespace MyProject.Domain.Model.Mapping
{
    public class ProductCategoryMap : ClassMap<ProductCategory>
    {
        public ProductCategoryMap()
        {
            Id(x => x.Id);
            Map(x => x.CategoryName);
           // HasMany(x => x.Products).Inverse();
        }
    }
}