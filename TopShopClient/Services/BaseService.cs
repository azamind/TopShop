namespace TopShopClient.Services
{
    public class BaseService
    {
        protected readonly HttpClient httpClient;
        protected readonly string domainUrl = "https://localhost:7251";

        public BaseService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

    }
}
