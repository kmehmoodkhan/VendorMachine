using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorMachine.Application.Interfaces;
using VendorMachine.Application.ViewModels;
using VendorMachine.Domain.Models;
using VendorMachine.Domain.Repository;

namespace VendorMachine.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductViewModel> GetProducts()
        {
            return new ProductViewModel
            {
                Products = await _productRepository.GetProducts()
            };
        }

        public Product GetProduct(int id)
        {
            var products = _productRepository.GetProducts();
            return products.Result.Where(p => p.ProductId == id).FirstOrDefault();
        }
    }
}
