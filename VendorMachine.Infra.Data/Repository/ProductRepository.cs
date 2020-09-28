using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorMachine.Domain.Models;
using VendorMachine.Domain.Repository;
using VendorMachine.Infra.Data.Mapper;

namespace VendorMachine.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                string basePath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("VendorMachine\\bin"));
                string location = basePath+@"VendorMachine.Infra.Data\Products.csv";
                TextReader reader = new StreamReader(location, Encoding.Default);
                var csv = new CsvReader(reader,CultureInfo.InvariantCulture);
                csv.Configuration.RegisterClassMap<ProductMap>();
                var records = csv.GetRecords<Product>();
                return records;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
