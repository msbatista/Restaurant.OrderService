using Microsoft.AspNetCore.Mvc;
using Restaurant.OrderService.Domain;
using Restaurant.OrederService.Services.Interfaces;
using System.Threading.Tasks;

namespace Restaurant.OrderService.Controllers.v1
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{cpf}")]
        public async Task<IActionResult> CreateOrder([FromRoute] long cpf, [FromBody] Order order)
        {
            var orderId = await _orderService.CreateOrder(cpf, order);

            return CreatedAtAction("", new { orderId });
        }
    }
}
