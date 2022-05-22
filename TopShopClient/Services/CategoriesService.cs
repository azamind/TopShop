using Newtonsoft.Json;
using TopShopClient.Models;

namespace TopShopClient.Services
{
    public class CategoriesService : BaseService
    {
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var url = new Uri(domainUrl + "/api/v1/categories");
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<Category>>(content);
                return data;
            }
            return null;
        }

    }
}
