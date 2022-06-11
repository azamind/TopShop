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
            multipartContent.Add(new StringContent(ProductData.ShortDescription), "ShortDescription");
            multipartContent.Add(new StringContent(JsonSerializer.Serialize(new List<string>() { ProductPhotoName })), "Photo");

            if (ProductData.Sizes != null)
            {
                foreach (var size in ProductData.Sizes)
                {
                    multipartContent.Add(new StringContent(JsonSerializer.Serialize(size)), "Sizes");
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
            return JsonSerializer.Deserialize<IEnumerable<string>>(response.Content.ReadAsStringAsync().Result).First();
        }

    }
}
