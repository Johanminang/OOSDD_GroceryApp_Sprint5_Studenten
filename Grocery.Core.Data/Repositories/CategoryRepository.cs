using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> categories;
        public CategoryRepository()
        {
            categories = [
                new Category(1, "Groente"),
                new Category(2, "Bakkerij"),
                new Category(3, "Zuivel"),
                new Category(4, "Conserveren"),
                new Category(5, "Ontbijt")
                ];
        }
        public Category? Get(int id)
        {
            return categories.FirstOrDefault(c => c.Id == id);
        }
        public List<Category> GetAll()
        {
            return categories;
        }
        public Category Add(Category item)
        {
            throw new NotImplementedException();
        }

        public Category? Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Category? Update(Category item)
        {
            Category? category = categories.FirstOrDefault(p => p.Id == item.Id);
            if (category == null) return null;
            category.Id = item.Id;
            return category;
        }

    }
}
