using System.Text.Json;
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
            multipartContent.Add(new StringContent(JsonSerializer.Serialize(new List<string>() { ProductPhotoName })), "Photo");

            var url = new Uri(domainUrl + "/api/v1/products");
            await httpClient.PostAsync(url, multipartContent);
        }

    }
}
