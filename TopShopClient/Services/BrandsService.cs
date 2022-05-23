using Newtonsoft.Json;
using TopShopClient.Models;

namespace TopShopClient.Services
{
    public class BrandsService : BaseService
    {
        public async Task<List<Brand>> GetBrandsAsync()
        {
            var url = new Uri(domainUrl + "/api/v1/brands");
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Brand>>(content);
            }
            return null;
        }
    }
}
