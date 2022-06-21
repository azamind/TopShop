using System.Web;
using TopShopClient.Models;
using TopShopClient.Services;

namespace TopShopClient.ViewModels.Product
{
    public class DetailViewModel : BaseViewModel, IQueryAttributable
    {
        private ProductDetail _product;

        public ProductDetail Product
        {
            get => _product;
            set
            {
                _product = value;
                OnPropertyChanged("Product");
            }
        }

        private ProductsService _productsService = new ProductsService();
     
        public DetailViewModel()
        {
            
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int productId = Int32.Parse(HttpUtility.UrlDecode((string)query["productId"]));
            LoadProduct(productId);
        }

        private async void LoadProduct(int productId)
        {
            try
            {
                Product = await _productsService.GetProductAsync(productId);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load product.");
            }
        }

    }
}
