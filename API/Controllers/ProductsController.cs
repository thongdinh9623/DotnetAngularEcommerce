using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MongoDBService<Product> _mongoDBService;

        public ProductsController(MongoDBService<Product> mongoDBService)
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

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> GetProduct(string id)
        {
            dynamic product = new ExpandoObject();
            product._id = "1";
            product.name = "HTML and CSS: Design and Build Websites First Edition";
            product.image = "/images/html-and-css.jpg";
            product.description = "A full-color introduction to the basics of HTML and CSS from the publishers of Wrox!";
            product.author = "Jon Duckett";
            product.category = "Web Development & Design";
            product.price = 17.29;
            product.countInStock = 10;
            product.rating = 4.5;
            product.numReviews = 12;

            return JsonSerializer.Serialize(product);
        }
    }
}
