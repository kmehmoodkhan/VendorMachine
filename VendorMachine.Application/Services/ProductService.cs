using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public ProductViewModel GetProducts()
        {
            return new ProductViewModel
            {
                Products = _productRepository.GetProducts()
            };
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProducts().Where(p => p.ProductId == id).FirstOrDefault();
        }
    }
}
