using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public class ProductCategory : Model 
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }  
        public ProductCategory(int id, int CategoryId, int ProductId) : base(id, "")
        {
            this.CategoryId = CategoryId;
            this.ProductId = ProductId;
        }

        public Product? Product { get; set; }
        public Category? Category { get; set; }
    }
}
