using MyProject.Domain.Model;
using NHibernate;
using System;
using System.Linq.Expressions;
using NHibernate.SqlCommand;
using NHibernate.Persister.Entity;
using System.Linq;
using System.Text;

namespace MyProject.Repository
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ISession session,  ITransaction transaction) : base(session, transaction)
        {
        }

        public override PagedEntity<Product> GetPaged(int page, int pageSize, Expression<Func<Product, bool>> expression, /*Expression<Func<Product, object>>*/string ordered)
        {
            var orderParam = ordered.Split(' ');
            Expression<Func<Product, object>> sortingExpression; // typeof(Product).GetProperty(orderParam[0]);
            //switch (orderParam[0])
            //{
            //    case "ProductCategory":
            //        sortingExpression = x => x.ProductCategory;
            //        break;
            //    case "ProductMatrixResolution":
            //        sortingExpression = x => x.ProductMatrixResolution;
            //        break;
            //    case "ProductPrice":
            //        sortingExpression = x => x.ProductPrice;
            //        break;
            //    case "ProductIrRange":
            //        sortingExpression = x => x.ProductIrRange;
            //        break;
            //    case "Type":
            //        sortingExpression = x => x.Type;
            //        break;
            //    default: sortingExpression = x => x.ProductName;
            //        break;
            //}
            if (orderParam[1] == "ASC")
            {
                PagedEntity<Product> result = new PagedEntity<Product>();
                _session.QueryOver<Product>()
                    .Where(expression)
                .UnderlyingCriteria.AddOrder(NHibernate.Criterion.Order.Asc(orderParam[0]));

                result.Items = _session.QueryOver<Product>()
                    .Where(expression).Skip(page * pageSize)
                    .Take(pageSize)
                   .List<Product>();

                result.Page = page;
                result.PageSize = pageSize;
                result.ItemCount = _session.QueryOver<Product>().Where(expression).RowCount();
                return result;
            }
            else
            {
            //    PagedEntity<Product> result = new PagedEntity<Product>();
            //    result.Items = _session.QueryOver<Product>()

            //        .Where(expression)
            //        .OrderBy(sortingExpression)
            //        .Desc
            //        .Skip(page * pageSize)
            //        .Take(pageSize)
            //        .List<Product>();

            //    result.Page = page;
            //    result.PageSize = pageSize;
            //    result.ItemCount = _session.QueryOver<Product>().Where(expression).RowCount();
            //    return result;
            //}
                return null;

            }


    }
}
