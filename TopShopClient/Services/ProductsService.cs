using Newtonsoft.Json;
using System.Text;
using TopShopClient.Models;

namespace TopShopClient.Services
{
    class ProductsService : BaseService
    {

        public async Task AddProductAsync(Product product)
        {
            var url = new Uri(domainUrl + "/api/v1/products");

            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(url, content);
        }

    }
}
