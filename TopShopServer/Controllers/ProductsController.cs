using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TopShopServer.DTOs;
using TopShopServer.Models;
using TopShopServer.Repositories.Product;

namespace TopShopServer.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;
        private IConfiguration _configuration;
        private IWebHostEnvironment _environment;
        private readonly IProductRepository _productRepository;
        private readonly IProductSizeRepository _productSizeRepository;

        public ProductsController(
            IMapper mapper,
            IConfiguration configuration,
            IWebHostEnvironment environment,
            IProductRepository productRepository, 
            IProductSizeRepository productSizeRepository
        ){
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration
                ?? throw new ArgumentNullException(nameof(configuration));
            _environment = environment
                ?? throw new ArgumentNullException(nameof(environment));
            _productRepository = productRepository 
                ?? throw new ArgumentNullException(nameof(productRepository));
            _productSizeRepository = productSizeRepository
                ?? throw new ArgumentNullException(nameof(productSizeRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts([FromQuery(Name = "CategoryId")] int? CategoryId)
        {
            var products = await _productRepository.GetProductsAsync(CategoryId);

            if (products == null)
            {
                return NotFound();
            }

            IList<ProductDto> productsDto = new List<ProductDto>();

            foreach (var product in products)
            {
                var photoLinks = new List<string>();
                var photos = JsonSerializer.Deserialize<IEnumerable<string>>(product.Photo);

                if (photos != null)
                {
                    foreach (var photo in photos)
                    {
                        photoLinks.Add(_configuration.GetValue<string>("hostRunning") + "/api/v1/products/images/" + photo);
                    }
                }

                productsDto.Add(new ProductDto
                {
                    Id = product.Id,
                    Photo = photoLinks,
                    BrandName = product?.Brand?.Name,
                    Title = product?.Title,
                    Price = product?.Price,
                    CreatedAt = product?.CreatedAt
                });
            }

            return Ok(productsDto);
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
                if (product == null)
                {
                    throw new Exception("Enter data cannot be empty.");
                }

                Product CreatedProduct = await _productRepository.Create(new Product
                {
                    BrandId = product.BrandId,
                    CategoryId = product.CategoryId,
                    Title = product.Title,
                    Description = product.Description,
                    ShortDescription = product.ShortDescription,
                    Code = product.Code,
                    Price = product.Price,
                    Article = product.Article,
                    Photo = product.Photo
                });

                if (product.Sizes.Count() > 0)
                {
                    await _productSizeRepository.Create(product.Sizes, CreatedProduct.Id);
                }

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

        [HttpGet("images/{name}")]
        public IActionResult GetPhoto(string Name)
        {
            string filePath = _environment.ContentRootPath + "\\images\\" + Name;
            return PhysicalFile(filePath, "image/jpeg");
        }

    }
}
