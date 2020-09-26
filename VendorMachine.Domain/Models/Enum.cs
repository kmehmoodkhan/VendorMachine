using System;
using System.Collections.Generic;
using System.Text;

namespace VendorMachine.Domain.Models
{
    public enum OrderStatus
    {
        None = 0,
        NotAvailable = 1,
        Success,
        LessAmount,
        QuantityNotAvailable
    }
}
