using Grocery.Core.Models;


namespace Grocery.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        public List<Category> GetAll();
        public Category? Get(int id);
        public Category Add(Category item);
        public Category? Update(Category item);
        public Category? Delete(Category item);
    }
}
