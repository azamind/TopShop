namespace TopShopClient.Services
{
    public class BaseService
    {
        protected readonly HttpClient _httpClient;
        protected const string domainUrl = "https://localhost:7251";

        public BaseService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

    }
}
