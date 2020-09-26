using System;
using System.Collections.Generic;
using System.Text;
using VendorMachine.Application.ViewModels;
using VendorMachine.Domain.Models;

namespace VendorMachine.Application.Interfaces
{
    public interface IProductPrintService
    {
        void PrintProducts(ProductViewModel products);

        void PrintOrder(OrderViewModel order, OrderStatus orderStatus);
    }
}
