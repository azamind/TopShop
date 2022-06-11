using Microsoft.AspNetCore.Mvc;
using TopShopServer.Models;
using TopShopServer.Repositories.Size;

namespace TopShopServer.Controllers
{
    public class SizesController : BaseController
    {
        private readonly ISizeRepository _sizeRepository;

        public SizesController(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository
                ?? throw new ArgumentNullException(nameof(sizeRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Size>>> GetSizes()
        {
            var sizes = await _sizeRepository.GetSizesAsync();

            if (sizes == null)
            {
                return NotFound();
            }

            return Ok(sizes);
        }
    }
}
