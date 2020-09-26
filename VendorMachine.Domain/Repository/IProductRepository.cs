using System;
using System.Collections.Generic;
using System.Text;
using VendorMachine.Domain.Models;

namespace VendorMachine.Domain.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        int OrderProduct(Product product);
    }
}
