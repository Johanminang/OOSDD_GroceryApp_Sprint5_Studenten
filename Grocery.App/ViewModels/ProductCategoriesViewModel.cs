using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(Category), nameof(Category))]
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private string searchText = "";
        public ObservableCollection<ProductCategory> ProductCategories { get; set; } = [];
        public ObservableCollection<Product> AvailableProducts { get; set; } = [];

        [ObservableProperty]
        Category? category;

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService, IProductService productService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
        }
        partial void OnCategoryChanged(Category? oldValue, Category newValue)
        {
            if (newValue == null) return;

            Title = $"Producten in {newValue.Name}";
            LoadProductCategories();
            GetAvailableProducts();
        }
        private void LoadProductCategories()
        {
            ProductCategories.Clear();

            var productCategories = _productCategoryService.GetAllOnCategoryId(Category.Id);

            foreach (var pc in productCategories)
            {
                // Vul productinformatie aan als deze ontbreekt
                if (pc.Product == null)
                {
                    var product = _productService.GetAll().FirstOrDefault(p => p.Id == pc.ProductId);
                    pc.Product = product;
                }

                ProductCategories.Add(pc);
            }
        }
        private void GetAvailableProducts()
        {
            AvailableProducts.Clear();

            var allProducts = _productService.GetAll();
            var usedProductIds = ProductCategories.Select(pc => pc.ProductId).ToList();

            foreach (var product in allProducts.Where(p => !usedProductIds.Contains(p.Id)))
                AvailableProducts.Add(product);
        }


        [RelayCommand]
        public async Task AddProduct(Product product)
        {
            if (product == null || Category == null)
                return;

            var newLink = new ProductCategory(0, Category.Id, product.Id);
            _productCategoryService.Add(newLink);
            newLink.Product = product;

            ProductCategories.Add(newLink);
            AvailableProducts.Remove(product);

            await Toast.Make($"Product '{product.Name}' toegevoegd aan {Category.Name}").Show();
        }

        [RelayCommand]
        public void PerformSearch(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                GetAvailableProducts();
                return;
            }

            var allProducts = _productService.GetAll();
            var usedProductIds = ProductCategories.Select(pc => pc.ProductId).ToList();

            var filtered = allProducts
                .Where(p => !usedProductIds.Contains(p.Id)
                         && p.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            AvailableProducts.Clear();
            foreach (var p in filtered)
                AvailableProducts.Add(p);
        }
    }
}
