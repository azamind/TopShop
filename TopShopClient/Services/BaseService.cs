namespace TopShopClient.Services
{
    public class BaseService
    {
        protected readonly HttpClient httpClient;
        public readonly string domainUrl = DeviceInfo.Current.Platform == DevicePlatform.Android 
            ? "http://10.0.2.2:5251"
            : "http://localhost:5251";

        public BaseService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

    }
}
