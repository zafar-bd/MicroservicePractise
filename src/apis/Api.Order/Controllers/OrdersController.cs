using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Api.Order.Dtos;
using Common.Events;
using MassTransit;

namespace Api.Order.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IBus _messageBus;

        public OrdersController(IBus messageBus)
        {
            _messageBus = messageBus;
        }
        [HttpPost]
        public async Task<IActionResult> Order([FromBody] OrderDto dto1)
        {
            OrderDto dto = new()
            {
                Id = 1,
                CustomerName = "customer",
                OrderItems = new()
                {
                    new() { Id = 1, ProductName = "product", Qty = 10 }
                }
            };

            OrderCreated orderCreatedEvent = new()
            {
                CustomerName = dto.CustomerName,
                Id = dto.Id
            };
            dto.OrderItems.ForEach(i =>
            {
                orderCreatedEvent.OrderItems.Add(new()
                {
                    Id = i.Id,
                    ProductName = i.ProductName,
                    Qty = i.Qty
                });
            });

            await _messageBus.Publish(orderCreatedEvent);

            return Created("", "");
        }
    }
}
