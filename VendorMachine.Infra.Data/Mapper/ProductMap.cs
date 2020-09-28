using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using VendorMachine.Domain.Models;

namespace VendorMachine.Infra.Data.Mapper
{
    public sealed class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Map(x => x.ProductId).Name("ProductId");
            Map(x => x.Name).Name("Name");
            Map(x => x.Quantity).Name("Quantity");
            Map(x => x.Price).Name("Price");
        }
    }
}
