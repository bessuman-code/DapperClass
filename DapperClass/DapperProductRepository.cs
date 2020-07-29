using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DapperClass
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public void InsertProducts(string newProductName)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name) VALUES (@productName);",
                new { productName = newProductName });
        }
    }
}
