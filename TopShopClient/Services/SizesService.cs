using MonkeyCache.FileStore;
using Newtonsoft.Json;

namespace TopShopClient.Services
{
    public class SizesService : BaseService
    {

        public async Task<List<Models.Size>> GetSizesAsync()
        {
            try
            {
                var url = new Uri(domainUrl + "/api/v1/sizes").ToString();

                if (!Barrel.Current.IsExpired(key: url))
                {
                    await Task.Yield();
                    return Barrel.Current.Get<List<Models.Size>>(key: url);
                }

                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<Models.Size>>(content);
                    Barrel.Current.Add(key: url, data: data, expireIn: TimeSpan.FromDays(1));
                    return data;
                }
                return new List<Models.Size>();
            }
            catch (Exception e)
            {
                Console.Write(e.Message.ToString());
            }

            return null;
        }
    }
}
