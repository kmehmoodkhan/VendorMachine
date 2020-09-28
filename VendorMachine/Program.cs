using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using VendorMachine.Application.Interfaces;
using VendorMachine.Application.ViewModels;
using VendorMachine.Infra.IoC;

namespace VendorMachine
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            DepedencyContainer.RegisterServices(services);

            Console.WriteLine("Please enter a command with required options. Below are given examples \n\n");
            Console.WriteLine("1. All Products e.g. 'inv' \n");
            Console.WriteLine("2. To Order any product e.g. 'order 5.67 2 3' \n");

            var console = serviceProvider.GetService<IVendorMachine>();
            console.HandleCommand();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            DepedencyContainer.RegisterServices(services);
            return services;
        }
    }
}
