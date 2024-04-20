using Microsoft.AspNetCore.Mvc;
using Tspu.Contract;
using Tspu.Models;
using Tspu.Service;

namespace Tspu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var products = productsService.Get();
            return Ok(products);
        }

        [HttpGet("(id)")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var product = productsService.Get(id);
            if (product == null)
            {
                return BadRequest($"Item {id} not found");
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddProductRequestContract requestProduct)
        {
            var newProduct = new Product()
            {
                Title = requestProduct.Title,
                Description = requestProduct.Description,
                Price = requestProduct.Price,
                ImageURL = requestProduct.ImageURL,

            };

            productsService.Add(newProduct);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product productRequest)
        {
            var pr = productsService.Update(productRequest);
            if (!pr)
            {
                return BadRequest("product not found");
            }
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var result = productsService.Delete(id);
            if(!result)
            {
                return BadRequest("product not found");

            }
            return NoContent();
        }

    }
}
