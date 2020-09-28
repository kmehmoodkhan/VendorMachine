using Microsoft.Extensions.DependencyInjection;
using System;
using VendorMachine.Application.Interfaces;
using VendorMachine.Application.Services;
using VendorMachine.Domain.Repository;
using VendorMachine.Infra.Data.Repository;

namespace VendorMachine.Infra.IoC
{
    public class DepedencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductPrintService, ProductPrintConsole>();
            services.AddScoped<IVendorMachine, VMConsole>();
        }
    }
}
