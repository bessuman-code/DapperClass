using Dapper;
using System.Collections.Generic;
using System.Data;//IDBCONNECTION
using System.Linq;

namespace DapperClass
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;//for queries & execute methods

        //Fiel/Local variable for making queries to the DataBase
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM bestbuy.departments;");
            //return _connection.Query<Department>("SELECT * FROM Departments;").ToList();
        }


        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",//@is going to be variable
            new { departmentName = newDepartmentName });
        }

        
    }

}
