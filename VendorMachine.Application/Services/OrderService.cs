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
    public class OrderService : IOrderService
    {
        IProductRepository _productRepository;
        public OrderService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public OrderStatus SubmitOrder(OrderViewModel orderDetail)
        {
            OrderStatus orderStatus = OrderStatus.None;

            var stock = _productRepository.GetProducts().Result.Where(p => p.ProductId == orderDetail.ProductId).FirstOrDefault();

            if (stock != null)
            {
                double requiredAmount = stock.Quantity * stock.Price;

                if (orderDetail.Quantity > stock.Quantity)
                {
                    orderStatus = OrderStatus.QuantityNotAvailable;
                }
                else if ((orderDetail.Quantity <= stock.Quantity && orderDetail.Amount >= requiredAmount))
                {
                    orderStatus = OrderStatus.LessAmount;
                }
                else
                {
                    orderStatus = OrderStatus.Success;
                }
            }
            else
            {
                orderStatus = OrderStatus.NotAvailable;
            }
            return orderStatus;
        }
    }
}
