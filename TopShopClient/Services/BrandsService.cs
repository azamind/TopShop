using MonkeyCache.FileStore;
using Newtonsoft.Json;
using TopShopClient.Models;

namespace TopShopClient.Services
{
    public class BrandsService : BaseService
    {
        public async Task<List<Brand>> GetBrandsAsync()
        {
            try
            {
                var url = new Uri(domainUrl + "/api/v1/brands").ToString();

                if (!Barrel.Current.IsExpired(key: url))
                {
                    await Task.Yield();
                    return Barrel.Current.Get<List<Brand>>(key: url);
                }
                
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<Brand>>(content);
                    Barrel.Current.Add(key: url, data: data, expireIn: TimeSpan.FromDays(1));
                    return data;
                }
                return new List<Brand>();
            } 
            catch(Exception e)
            {
                Console.Write(e.Message.ToString());
            }
            
            return null;
        }
    }
}
