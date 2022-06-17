using Newtonsoft.Json;
using System.Web;
using TopShopClient.Models;

namespace TopShopClient.Services
{
    class ProductsService : BaseService
    {

        public async Task AddProductAsync(Product ProductData, string ProductPhotoName)
        {
            MultipartFormDataContent multipartContent = new MultipartFormDataContent();
            multipartContent.Headers.ContentType.MediaType = "multipart/form-data";
            multipartContent.Add(new StringContent(ProductData.Title), "Title");
            multipartContent.Add(new StringContent(Convert.ToString(ProductData.BrandId)), "BrandId");
            multipartContent.Add(new StringContent(Convert.ToString(ProductData.CategoryId)), "CategoryId");
            multipartContent.Add(new StringContent(ProductData.Code), "Code");
            multipartContent.Add(new StringContent(ProductData.Article), "Article");
            multipartContent.Add(new StringContent(Convert.ToString(ProductData.Price)), "Price");
            multipartContent.Add(new StringContent(ProductData.Description), "Description");
            multipartContent.Add(new StringContent(ProductData.ShortDescription), "ShortDescription");
            multipartContent.Add(new StringContent(System.Text.Json.JsonSerializer.Serialize(new List<string>() { ProductPhotoName })), "Photo");

            if (ProductData.Sizes != null)
            {
                foreach (var size in ProductData.Sizes)
                {
                    multipartContent.Add(new StringContent(System.Text.Json.JsonSerializer.Serialize(size)), "Sizes");
                }
            }
            
            var url = new Uri(domainUrl + "/api/v1/products");
            await httpClient.PostAsync(url, multipartContent);
        }

        public async Task<string> UploadPhoto(FileResult result)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StreamContent(await result.OpenReadAsync()), "file", result.FileName);

            var url = new Uri(domainUrl + "/api/v1/products/images");
            var response = await httpClient.PostAsync(url, content);
            return System.Text.Json.JsonSerializer.Deserialize<IEnumerable<string>>(response.Content.ReadAsStringAsync().Result).First();
        }

        public async Task<IList<ProductList>> GetProductsAsync(int CategoryId)
        {
            var uriBuilder = new UriBuilder(domainUrl + "/api/v1/products");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["CategoryId"] = CategoryId.ToString();
            uriBuilder.Query = query.ToString();
            var url = uriBuilder.ToString();
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<ProductList>>(content);
            }
            return new List<ProductList>();
        }

        public async Task<Product> GetProductAsync(int ProductId)
        {
            var url = new Uri(domainUrl + "/api/v1/products/" + ProductId);
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Product>(content);
            }

            return new Product();
        }
 
    }
}
