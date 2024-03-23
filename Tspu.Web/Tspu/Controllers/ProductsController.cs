using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tspu.Contract;
using Tspu.Новая_папка;

namespace Tspu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> products= new List<Product>();
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }

        [HttpGet("(id)")]
        public IActionResult Get([FromRoute] Guid id)
        {
            foreach (var product in products) {
            if (product.Id == id) return Ok(product);
            }

            return BadRequest($"Item {id} not found");
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddProductRequestContract requestProduct)
        {
            var newProduct = new Product()
            {
                Id = Guid.NewGuid(),
                Title = requestProduct.Title,
                Description = requestProduct.Description,
                Price = requestProduct.Price,
                ImageURL = requestProduct.ImageURL,

            };

            products.Add(newProduct);
            return Ok();
        }

        //[HttpPut]
        //public IActionResult Put([FromBody] Product product)
        //{
            
        //    foreach (var product in products) {
        //    if (product.Id == id) return Ok(product);
        //    }
        //}
    }
}
