using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;


namespace Grocery.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public ProductCategory Add(ProductCategory item)
        {
            return _productCategoryRepository.Add(item);
        }

        public List<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public List<ProductCategory> GetAllOnCategoryId(int id)
        {
            var allItems = _productCategoryRepository.GetAll();
            return allItems.Where(pc => pc.CategoryId == id).ToList();
        }
        public ProductCategory? Get(int id)
        {
            return _productCategoryRepository.Get(id);
        }
        public ProductCategory? Update(ProductCategory item)
        {
            return _productCategoryRepository.Update(item);
        }
        public ProductCategory? Delete(ProductCategory item)
        {
            throw new NotImplementedException();
        }
    }
}
