using MonkeyCache.FileStore;
using Newtonsoft.Json;
using TopShopClient.Models;

namespace TopShopClient.Services
{
    public class CategoriesService : BaseService
    {

        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                var url = new Uri(domainUrl + "/api/v1/categories").ToString();

                if (!Barrel.Current.IsExpired(key: url))
                {
                    await Task.Yield();
                    return Barrel.Current.Get<List<Category>>(key: url);
                }

                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<Category>>(content);
                    Barrel.Current.Add(key: url, data: data, expireIn: TimeSpan.FromDays(1));
                    return data;
                }
                return new List<Category>();
            }
            catch (Exception e)
            {
                Console.Write(e.Message.ToString());
            }

            return null;
        }

    }
}
