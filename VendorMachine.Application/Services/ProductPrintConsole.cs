using System;
using System.Collections.Generic;
using System.Text;
using VendorMachine.Application.Interfaces;
using VendorMachine.Application.ViewModels;
using VendorMachine.Domain.Models;

namespace VendorMachine.Application.Services
{
    public class ProductPrintConsole:IProductPrintService
    {
        public void PrintOrder(OrderViewModel order,OrderStatus orderStatus)
        {
            switch (orderStatus)
            {
                case OrderStatus.Success:
                    {
                        Console.WriteLine($"{order.Name} ({order.Quantity}) order has been placed successfully");
                    }
                    break;
                case OrderStatus.LessAmount:
                    Console.WriteLine($"Order failed because more amount is required to buy {order.Name}");
                    break;
                case OrderStatus.NotAvailable:
                    Console.WriteLine($"Order failed because {order.Name} stock was not available.");
                    break;
                case OrderStatus.QuantityNotAvailable:
                    Console.WriteLine($"Order failed because {order.Name} required quantity is not available.");
                    break;
                case OrderStatus.None:
                    break;
            }
        }

        public void PrintProducts(ProductViewModel productViewModel)
        {
            var products = productViewModel.Products;

            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductId} ({p.Quantity}):{String.Format("{0:C}", p.Price)}");
            }
        }
    }
}
