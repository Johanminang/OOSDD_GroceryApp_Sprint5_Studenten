using Grocery.Core.Models;


namespace Grocery.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        public List<Category> GetAll();
        public Category Add(Category item);
        public Category? Update(Category item);
        public Category? Delete(Category item);
        public Category? Get(int id);
    }
}
