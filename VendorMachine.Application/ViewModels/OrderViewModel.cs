using System;
using System.Collections.Generic;
using System.Text;

namespace VendorMachine.Application.ViewModels
{
    public class OrderViewModel
    {
        public string Name
        {
            get;
            set;
        }
        public int ProductId
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }
    }
}
