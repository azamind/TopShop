using Microsoft.AspNetCore.Mvc;
using TopShopServer.Models;
using TopShopServer.Repositories.Category;

namespace TopShopServer.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository
                 ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetProducts()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();

            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

    }
}
