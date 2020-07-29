using Dapper;
using System.Collections.Generic;
using System.Data;

namespace DapperClass
{
    public interface IDepartmentRepository
    {
        //Saying we need a method called GetAllDepartments that returns a collection
        //That conforms to IEnumerable<T>
        public IEnumerable<Department> GetAllDepartments();
        
    }
}
