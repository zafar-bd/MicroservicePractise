using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Common.Logging;
using MassTransit;
using Serilog;

namespace Worker.Order
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GlobalLogger.ConfigureLog();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(mt =>
                    {
                        mt.AddConsumer<OrderConsumerForOrderService>();
                        mt.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host("rabbitmq://localhost", crd =>
                            {
                                crd.Username("guest");
                                crd.Password("guest");
                            });

                            cfg.ReceiveEndpoint("order-for-order", con =>
                            {
                                con.ConfigureConsumer<OrderConsumerForOrderService>(context);
                            });
                        });
                    });
                    services.AddMassTransitHostedService();
                });
    }
}
