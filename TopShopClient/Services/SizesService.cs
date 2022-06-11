using Newtonsoft.Json;

namespace TopShopClient.Services
{
    public class SizesService : BaseService
    {
        public async Task<List<Models.Size>> GetSizesAsync()
        {
            var url = new Uri(domainUrl + "/api/v1/sizes");
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Models.Size>>(content);
            }
            return new List<Models.Size>();
        }
    }
}
