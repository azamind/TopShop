using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TopShopServer.DTOs;
using TopShopServer.Models;
using TopShopServer.Repositories.Product;
using TopShopServer.Services;

namespace TopShopServer.Controllers
{
    public class ProductsController : BaseController
    {
        private IWebHostEnvironment _environment;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(
            IProductRepository productRepository, 
            IMapper mapper, 
            IWebHostEnvironment environment
            )
        {
            _environment = environment
                ?? throw new ArgumentNullException(nameof(environment));
            _productRepository = productRepository 
                ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();

            if(products == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] Product product)
        {
            try
            {
                /*IList<string> fileNames = new List<string>();
                var httpRequest = HttpContext.Request;

                if (httpRequest.Form.Files.Count > 0)
                {
                    foreach (var file in httpRequest.Form.Files)
                    {
                        string Name = $"{DateTime.Now.ToFileTime()}" + "-" + file.FileName;
                        var filePath = Path.Combine(_environment.ContentRootPath, "images");
                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);    

                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            System.IO.File.WriteAllBytes(Path.Combine(filePath, Name), memoryStream.ToArray());
                        }

                        fileNames.Add(Name);
                    }
                }*/

                await _productRepository.Create(new Product
                {
                    BrandId = product.BrandId,
                    CategoryId = product.CategoryId,
                    Title = product.Title,
                    Description = product.Description,
                    Code = product.Code,
                    Price = product.Price,
                    Article = product.Article,
                    Photo = product.Photo
                });

                return Created("/", "Data successfully created.");
            } 
            catch (Exception e) 
            {
                return BadRequest(e.StackTrace);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(int id, Product product)
        {
            await _productRepository.Update(id, product);
            return NoContent();
        }

        [HttpPost("images")]
        public async Task<ActionResult<IList<string>>> PhotosUpload()
        {
            IList<string> fileNames = new List<string>();
            var httpRequest = HttpContext.Request;

            if (httpRequest.Form.Files.Count > 0)
            {
                foreach (var file in httpRequest.Form.Files)
                {
                    string Name = $"{DateTime.Now.ToFileTime()}" + "-" + file.FileName;
                    var filePath = Path.Combine(_environment.ContentRootPath, "images");
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);

                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        System.IO.File.WriteAllBytes(Path.Combine(filePath, Name), memoryStream.ToArray());
                    }

                    fileNames.Add(Name);
                }
            }

            return Ok(fileNames);
        }

    }
}
