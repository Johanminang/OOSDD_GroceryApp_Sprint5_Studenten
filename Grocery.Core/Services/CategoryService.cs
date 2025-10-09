using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category Add(Category item)
        {
            throw new NotImplementedException();
        }

        public Category? Update(Category item) 
        {
            return _categoryRepository.Update(item);
        }

        public Category? Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Category? Get(int id)
        {
            return _categoryRepository.Get(id);
        }        
    }
}
