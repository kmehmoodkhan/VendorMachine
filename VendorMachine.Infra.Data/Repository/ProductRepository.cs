using System;
using System.Collections.Generic;
using System.Text;
using VendorMachine.Domain.Models;
using VendorMachine.Domain.Repository;

namespace VendorMachine.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product() { ProductId = 1, Name = "Coke", Quantity = 10, Price = 1.25 });
            products.Add(new Product() { ProductId = 2, Name = "M&M’s", Quantity = 15, Price = 1.89 });
            products.Add(new Product() { ProductId = 3, Name = "Water", Quantity = 5, Price = 0.89 });
            products.Add(new Product() { ProductId = 4, Name = "Snickers", Quantity = 7, Price = 2.05 });
            return products;
        }

        public int OrderProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
