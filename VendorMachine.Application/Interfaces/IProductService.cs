using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VendorMachine.Application.ViewModels;
using VendorMachine.Domain.Models;

namespace VendorMachine.Application.Interfaces
{
   public interface IProductService
    {
        Task<ProductViewModel> GetProducts();

        Product GetProduct(int id);

        
    }
}
