using Microsoft.AspNetCore.Mvc;
using Restaurant.OrderService.Domain;
using Restaurant.OrederService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.OrderService.Controllers.v1
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertProducts([FromBody] IEnumerable<Product> products)
        {
            var affectedRows = await _productService.InsertProducts(products);

            return Ok(new { affectedRows });
        }
    }
}
