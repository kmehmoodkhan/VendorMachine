using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VendorMachine.Domain.Models;

namespace VendorMachine.Domain.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}
