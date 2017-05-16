using NHibernate;
using System.Linq;
using MyProject.Infrastructure;
using MyProject.Repository;
using System;
using MyProject.Repository.Interface;
using NHibernate.Criterion;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var session =new NHibernateProvider();
            IRepository<Product> myprod = new Repository<Product>(session.SessionFactory.OpenSession());

            var x = myprod.GetPaged(1, 5,z=>z.ProductPrice>=150,y=>y.ProductPrice);
            foreach (var item in x.Items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"Page {x.Page}/{x.Pages} Showing {(x.Page - 1)*x.PageSize+1}-{(x.Page - 1) * x.PageSize+x.PageSize}  from {x.ItemCount}");
            //  NHibernateProvider.GetSession();

            // UserRepository UserRep;
            //NHibernateProvider provider = new NHibernateProvider();
            //var session = provider.SessionFactory.OpenSession();
            //Repository<ProductCategory> pc = new Repository<ProductCategory>(session);

               
            //  ITransaction transaction = session.BeginTransaction();

            //   var catRepositoryegoryrep = new Repository<ProductCategory>();
            //  var listCategorys = catRepositoryegoryrep.GetAll();

            //foreach (var item in listCategorys)
            //{
            //    Console.WriteLine(item.Id +" "+item.CategoryName);
            //}

            //var x = session.QueryOver<Order>().Where(y =>y.Id == 13).SingleOrDefault();
            //Console.WriteLine(x.Id);
            //session.Delete(x);
            //transaction.Commit();
            //ProductCategory productCategory = new ProductCategory() { CategoryName = "Dome" };
            //session.SaveOrUpdate(productCategory);
            //productCategory = new ProductCategory() { CategoryName = "Bulet" };
            //session.SaveOrUpdate(productCategory);
            //productCategory = new ProductCategory() { CategoryName = "PTZ" };
            //session.SaveOrUpdate(productCategory);
            //productCategory = new ProductCategory() { CategoryName = "SPY" };
            //session.SaveOrUpdate(productCategory);
            //transaction.Commit();


            //var listCaterory = pc.GetAll();

            //Product p1 = new Product();
            //p1.ProductCategory = listCaterory.Where(x => x.CategoryName == "Bulet").SingleOrDefault();
            //p1.ProductCategory.AddProduct(p1);
            //p1.ProductName = "Camera 1";
            //p1.ProductVisibility = false;
            //p1.ProductIrRange = 10;
            //p1.ProductPrice = 120;
            //p1.Type = Type.External;
            //p1.ProductStock = 10;
            //p1.ProductDescription = "Nice camera";
            //session.SaveOrUpdate(p1);
            //transaction.Commit();

            //    OrderRepository orderRep = new OrderRepository();

            //    var listRows = orderRep.GetOrderDetailsRows(9);
            //    Console.WriteLine(" Order Detail Rows By User ID Using AliasToBean + string Formating");
            //    foreach (var item in listRows)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }


            //    Console.WriteLine("\n Display User With Maximum number of orders");
            //    var usermaxorder = UserRep.GetUserWithMaxOrders();
            //    Console.WriteLine($"User: {usermaxorder[0]} has {usermaxorder[1]} orders");


            //    var list = orderRep.AllCustomerOrderProductsByUserId(9);
            //    Console.WriteLine("\n Products from customer Id =3");
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine($">>User: {item.Order.User.Id} in Order: {item.Order.Id} has ItemID: {item.Id} ");
            //    }



            //    var userWithOrders = UserRep.GetUsersWithOrders();
            //    Console.WriteLine("\n User Has Orders");
            //    foreach (var item in userWithOrders)
            //    {
            //        Console.WriteLine($"User: {item.Id} has orders");
            //    }

            //    var userId = orderRep.UserIdByOrderId(14);
            //    Console.WriteLine($"\n The ID of the owner of order with id 14 is \n UserId: {userId}");

            //    using (var tx = session.BeginTransaction())
            //    {
            //     var userList = session.QueryOver<User>()
            //            .Future<User>();

            //    var numOfOrders = session.CreateCriteria<User>()
            //        .SetProjection(Projections.Count(Projections.Id()))
            //        .FutureValue<int>();



            //    Console.WriteLine($"\n We have {numOfOrders.Value} users");
            //        foreach (var item in userList)
            //        {
            //            Console.WriteLine(item.Id);
            //        }
            //    tx.Commit();
            //}
            //var me = UserRep.Get(9);

            //var order = new Order();
            //var order2 = new Order();

            //var orderproduct1 = new OrderProduct();
            //var orderproduct2 = new OrderProduct();
            //var orderproduct3 = new OrderProduct();
            //var orderproduct4 = new OrderProduct();


            //order.AddOrderProduct(orderproduct1);
            //order.AddOrderProduct(orderproduct2);

            //order2.AddOrderProduct(orderproduct3);
            //order2.AddOrderProduct(orderproduct4);


            //me.AddOrder(order);
            //me.AddOrder(order2);

            //UserRep.Save(me);
            //  Console.ReadLine();
        }
    }
}
