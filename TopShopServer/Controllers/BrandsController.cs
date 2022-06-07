using Microsoft.AspNetCore.Mvc;
using TopShopServer.Models;
using TopShopServer.Repositories.Brand;

namespace TopShopServer.Controllers
{
    public class BrandsController : BaseController
    {
        private readonly IBrandRepository _brandRepository;

        public BrandsController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository
                ?? throw new ArgumentNullException(nameof(brandRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            var brands = await _brandRepository.GetBrandsAsync();

            if (brands == null)
            {
                return NotFound();
            }

            return Ok(brands);
        }

    }
}
