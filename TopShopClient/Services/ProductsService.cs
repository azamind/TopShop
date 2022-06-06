using TopShopClient.Models;

namespace TopShopClient.Services
{
    class ProductsService : BaseService
    {

        public async Task AddProductAsync(Product ProductData, IList<ProductPhoto> ProductPhotos)
        {
            MultipartFormDataContent multipartContent = new MultipartFormDataContent();
            multipartContent.Headers.ContentType.MediaType = "multipart/form-data";

            /*foreach (ProductPhoto productPhoto in ProductPhotos)
            {

            }*/

            multipartContent.Add(new StringContent(ProductData.Title), "Title");
            multipartContent.Add(new StringContent(Convert.ToString(ProductData.BrandId)), "BrandId");
            multipartContent.Add(new StringContent(Convert.ToString(ProductData.CategoryId)), "CategoryId");
            multipartContent.Add(new StringContent(ProductData.Code), "Code");
            multipartContent.Add(new StringContent(ProductData.Article), "Article");
            multipartContent.Add(new StringContent(Convert.ToString(ProductData.Price)), "Price");
            multipartContent.Add(new StringContent(ProductData.Description), "Description");

            var url = new Uri(domainUrl + "/api/v1/products");
            await _httpClient.PostAsync(url, multipartContent);
        }

    }
}
