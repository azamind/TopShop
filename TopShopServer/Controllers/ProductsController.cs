using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopShopServer.DTOs;
using TopShopServer.Models;
using TopShopServer.Repositories.Product;

namespace TopShopServer.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository 
                ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Lists()
        {
            var products = await _productRepository.GetProductsAsync();

            if(products == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

    }
}
