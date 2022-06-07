using Newtonsoft.Json;
using TopShopClient.Models;

namespace TopShopClient.Services
{
    public class CategoriesService : BaseService
    {
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var url = new Uri(domainUrl + "/api/v1/categories");
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Category>>(content);
            }
            return null;
        }

    }
}
