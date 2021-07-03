using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Worker.Order
{
    public class OrderConsumerForOrderService : IConsumer<OrderCreated>
    {
        private readonly ILogger<OrderConsumerForOrderService> _logger;

        public OrderConsumerForOrderService(ILogger<OrderConsumerForOrderService> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<OrderCreated> context)
        {
            _logger.LogInformation($"{nameof(OrderCreated)} event received at {DateTime.Now} of {context.Message.CustomerName}");
            _logger.LogWarning($"{nameof(OrderCreated)} event received at {DateTime.Now} of {context.Message.CustomerName}");
            _logger.LogError($"{nameof(OrderCreated)} event received at {DateTime.Now} of {context.Message.CustomerName}");
            OrderCreated message = context.Message;
            await Task.CompletedTask;
        }
    }
}
