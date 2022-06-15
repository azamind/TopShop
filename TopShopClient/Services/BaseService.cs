namespace TopShopClient.Services
{
    public class BaseService
    {
        protected readonly HttpClient httpClient;
        protected readonly string domainUrl = DeviceInfo.Current.Platform == DevicePlatform.Android 
            ? "http://192.168.1.177:5251"
            : "http://localhost:5251";

        public BaseService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

    }
}
