using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Interfaces.Services
{
    public interface IProductCategoryService
    {
        public ProductCategory Add(ProductCategory item);
        public List<ProductCategory> GetAll();
        public List<ProductCategory> GetAllOnCategoryId(int id);
    }
}
