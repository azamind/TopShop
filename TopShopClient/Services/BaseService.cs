namespace TopShopClient.Services
{
    public class BaseService
    {
        public readonly HttpClient httpClient;
        public readonly string domainUrl = "https://localhost:7251";

        public BaseService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

    }
}
