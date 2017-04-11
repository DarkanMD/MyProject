using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;


namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {

            var connectionString = ConfigurationManager.ConnectionStrings["MyProject.Properties.Settings.SQL"];
            System.Console.WriteLine(connectionString);

            var providerName = connectionString.ProviderName;
           

            var factory = DbProviderFactories.GetFactory(providerName);
            
            var connection = factory.CreateConnection();
            connection.ConnectionString = connectionString.ToString();
            connection.Open();

            string com = "";

            using (var command = connection.CreateCommand())
            {
                command.CommandText = com;
                command.ExecuteNonQuery();
            }
            connection.Close();

        

        }
    }
}
