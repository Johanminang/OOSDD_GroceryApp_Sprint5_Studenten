using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> productCategories;
        public ProductCategoryRepository()
        {
            productCategories = [
                new ProductCategory(1, 3, 1),
                new ProductCategory(2, 3, 2),
                new ProductCategory(3, 2, 3),
                new ProductCategory(4, 5, 4)
                ];
        }
        
        public List<ProductCategory> GetAll()
        {
            return productCategories;
        }
        public ProductCategory? Get(int id)
        {
            return productCategories.FirstOrDefault(p => p.Id == id);
        }

        public ProductCategory Add(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public ProductCategory? Update(ProductCategory item)
        {
            ProductCategory? productCategory = productCategories.FirstOrDefault(p => p.Id == item.Id);
            if (productCategory == null) return null;
            productCategory.Id = item.Id;
            return productCategory;
        }

    }
}
