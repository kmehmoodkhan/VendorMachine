using System;
using System.Collections.Generic;
using System.Text;

namespace VendorMachine.Domain.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }
    }
}
