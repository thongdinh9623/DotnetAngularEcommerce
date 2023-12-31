using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMongoDbService<Product> _mongoDBService;

        public ProductsController(IMongoDbService<Product> mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            List<Product> products = await _mongoDBService.GetAsync();

            return products;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Invalid product id");
            }
            Product product = await _mongoDBService.GetByIdAsync(id);

            return product ?? (ActionResult<Product>)NotFound();
        }
    }
}
