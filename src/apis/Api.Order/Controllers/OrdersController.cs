using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Api.Order.Dtos;
using Common.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Api.Order.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IBus _messageBus;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IBus messageBus, ILogger<OrdersController> logger)
        {
            _messageBus = messageBus;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Order()
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

            OrderDto dto2 = new()
            {
                Id = 2,
                CustomerName = "customer 2",
                OrderItems = new()
                {
                    new() { Id = 1, ProductName = "product 2", Qty = 10 }
                }
            };
            await _messageBus.Publish<OrderCreated>(orderCreatedEvent);

            _logger.LogInformation($"{nameof(OrderCreated)} event sent at {DateTime.Now}");

            return Created("", "");
        }
    }
}
