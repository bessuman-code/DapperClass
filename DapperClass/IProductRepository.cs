using System;
using System.Collections.Generic;
using System.Text;

namespace DapperClass
{
   public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();

    }
}
