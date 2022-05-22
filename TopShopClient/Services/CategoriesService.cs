using Newtonsoft.Json;
using TopShopClient.Models;

namespace TopShopClient.Services
{
    public class CategoriesService : BaseService
    {
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var url = new Uri(domainUrl + "/api/Categories");
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Category>>(content);
            }
            return null;
        }

    }
}
