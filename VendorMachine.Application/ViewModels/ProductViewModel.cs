using System;
using System.Collections.Generic;
using System.Text;
using VendorMachine.Domain.Models;

namespace VendorMachine.Application.ViewModels
{
   public class ProductViewModel
    {
        public IEnumerable<Product> Products
        {
            get;
            set;
        }

    }
}
