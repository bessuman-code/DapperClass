using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Drawing.Printing;

namespace DapperClass
{
    class Program
    {
        /*static IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        static string connString = config.GetConnectionString("DefaultConnection");
        static IDbConnection conn = new MySqlConnection(connString);*/
        //IDbConnection conn = new MySqlConnection(connString);
        /*var userInteraction = new UserInteraction(conn);
        userInteraction.ListProducts();
            userInteraction.DeleteProducts();
            userInteraction.ListProducts();*/
        static void Main(string[] args)
        {
          //#region configuration
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");//read from json file
            IDbConnection conn = new MySqlConnection(connString);//connection to connect to connetc mySQL database
            var repo = new DapperDepartmentRepository(conn);
            var repod = new DapperProductRepository(conn);
           var departments =  repo.GetAllDepartments();
            var products = repod.GetAllProducts();
            Print(departments);
            Print(products);
            

            Console.WriteLine("Want to add a department?");
            string userResponse = Console.ReadLine();

            if (userResponse.ToLower() == "yes")
            {
                Console.WriteLine("what is depart. name?");
                userResponse = Console.ReadLine();
                repo.InsertDepartment(userResponse);
                Print(repo.GetAllDepartments());
            }
            Console.WriteLine("Have a nice day");
        }
        public static void Print(IEnumerable<Department> departments)
        {
            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
            }
        }
        public static void Print(IEnumerable<Product> products)
        {
            foreach (var pdt in products)
            {
                Console.WriteLine($"{pdt.ProductID} {pdt.Name} {pdt.StckLevel}");
            }
        }
    }
}
