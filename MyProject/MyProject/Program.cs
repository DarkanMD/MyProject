using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using NHibernate.Util;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Transform;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ISession session = NHibernateProvider.GetSession();
            ITransaction transaction = session.BeginTransaction();
            //ProductRepository myp = new ProductRepository(NHibernateProvider.GetSession());
           // var tx =session.BeginTransaction();
            // session.SaveOrUpdate(new Product("1.3Mpx Camera", "Bulet Camera", 90, 25, "No Description", true));
           // var testitem = session.Get<CartProduct>(1);
           // Console.WriteLine($"{testitem.CartProductId} {testitem.Product.ProductName} {testitem.Quantity}(Price{testitem.Product.ProductPrice}) {testitem.Subtotal}");
          //  session.SaveOrUpdate(new CartProduct(testitem,10));
           // tx.Commit();
       
           // myp.Save(new Product("1.3Mpx Camera", "Bulet Camera", 90, 25, "No Description", true));
          
           // myp.Delete(x);
           //User me = new User();
           //var cart = new Cart();
           // me.AddCart(cart);
            
          //session.SaveOrUpdate(me);
            var usertodelete =session.Get<User>(6);
            session.Delete(usertodelete);
            transaction.Commit();

            //var connectionString = ConfigurationManager.ConnectionStrings["SQL"].ToString();
            ////System.Console.WriteLine(connectionString);
            ////var providerName = connectionString.ProviderName;
            ////var factory = DbProviderFactories.GetFactory(providerName);
            ////var connection = factory.CreateConnection();
            ////connection.ConnectionString = connectionString.ToString();

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();

            //    string com = @"CREATE TABLE Users
            //(
            //    UserID int primary key IDENTITY(1, 1),
            //UserName nvarchar(100) not null,
            //UserAddress nvarchar(100) not null,
            //UserEmailAddress nvarchar(100) not null,
            //UserPassword  nvarchar(100) not null,
            //UserRole Bit not null,
            //    )

            //    create table Products
            //(
            //    ProductId int primary key IDENTITY(1, 1),
            //ProductName nvarchar(100) not null,
            //ProductCategory nvarchar(100) not null,
            //ProductPrice money not null,
            //ProductStock int not null,
            //ProductDescription nvarchar(100) not null,
            //ProductVisibility Bit not null,
            //    )

            //    create table Carts
            //(
            //    CartID int primary key IDENTITY(1, 1),
            //UserID int not null,
            //FOREIGN KEY(UserID)
            //references Users(UserID),
            //)
            //    Create table CartContent
            //(
            //    ID int primary key IDENTITY(1, 1),
            //CartID int not null,
            //FOREIGN KEY(CartID)
            //references Carts(CartID),
            //ProductID int not null,
            //FOREIGN KEY(ProductID)
            //references Products(ProductID),
            //Subtotal money not null,
            //    )";

            //    //using (var command = connection.CreateCommand())
            //    //{
            //    //    command.CommandText = com;
            //    //    command.ExecuteNonQuery();
            //    //   // Console.WriteLine(xx);
            //    //}

            //    int id = 2;

            //    Product X;
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        cmd.CommandText = ("SELECT * FROM Products WHERE ProductId = @id");
            //        cmd.Parameters.Add("@id", SqlDbType.Int);
            //        cmd.Parameters["@id"].Value = id;
            //        // uses an extension method which I will demonstrate in a 
            //        // blog post in a couple of days
            //        var xx = cmd.ExecuteReader(); //FirstOrDefault<Product>(); //FirstOrDefault<Product>();
            //        while (xx.Read())
            //        {
            //            X = new Product((int) xx["ProductId"], (string) xx["ProductName"],
            //                (string) xx["ProductCategory"], (decimal) xx["ProductPrice"], (int) xx["ProductStock"],
            //                (string) xx["ProductDescription"], (bool) xx["ProductVisibility"]);
            //            Console.WriteLine($"{X.ProductId}, {X.ProductCategory}");
            //        }
            //    }

            //    connection.Close();

            //}

        }
    }
}
