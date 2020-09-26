using Microsoft.Extensions.DependencyInjection;
using System;
using VendorMachine.Application.Interfaces;
using VendorMachine.Application.ViewModels;
using VendorMachine.Infra.IoC;

namespace VendorMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();


            DepedencyContainer.RegisterServices(services);
            var productService = serviceProvider.GetService<IProductService>();

            var printService = serviceProvider.GetService<IProductPrintService>();
            var orderService = serviceProvider.GetService<IOrderService>();

            string command = args[0];
            if (command == "inv")
            {                
                var products = productService.GetProducts();
                printService.PrintProducts(products);
            }
            else if (command.StartsWith("order"))
            {
                double price = Convert.ToDouble(args[1]);
                int productId = Convert.ToInt32(args[2]);
                int quantity = Convert.ToInt32(args[3]);

                OrderViewModel order = new OrderViewModel() { ProductId = productId, Amount = price, Quantity = quantity };

                var status = orderService.SubmitOrder(order);

                var product = productService.GetProduct(productId);

                if(product != null)
                {
                    order.Name = product.Name;
                }

                printService.PrintOrder(order, status);
            }

            Console.Read();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            DepedencyContainer.RegisterServices(services);
            return services;
        }
    }
}
