using System;
using System.Threading.Tasks;
using VendorMachine.Application.Interfaces;
using VendorMachine.Application.ViewModels;


namespace VendorMachine.Application.Services
{
    public class VMConsole:IVendorMachine
    {
        IProductService _productService;
        IProductPrintService _printService;
        IOrderService _orderService;
        public VMConsole(IProductService productService, IProductPrintService printService, IOrderService orderService)
        {
            _productService = productService;
            _printService = printService;
            _orderService = orderService;
        }
        public async void HandleCommand()
        {
            do
            {

                string command = Console.ReadLine();


                if (command == "inv")
                {
                    var products = await _productService.GetProducts();
                    _printService.PrintProducts(products);
                }
                else if (command.StartsWith("order"))
                {
                    string[] arguments = command.Split(' ');

                    double price = 0;
                    int productId = 0;
                    int quantity = 0;

                    bool isValidArgs = false;

                    if (arguments.Length <= 4)
                    {
                        isValidArgs = true;
                        try { price = Convert.ToDouble(arguments[1]); } catch (Exception ex) { isValidArgs = false; }
                        try { productId = Convert.ToInt32(arguments[2]); } catch (Exception ex) { isValidArgs = false; }
                        try { quantity = Convert.ToInt32(arguments[3]); } catch (Exception ex) { isValidArgs = false; }

                        if (isValidArgs)
                        {
                            OrderViewModel order = new OrderViewModel() { ProductId = productId, Amount = price, Quantity = quantity };

                            var status = _orderService.SubmitOrder(order);

                            var product = _productService.GetProduct(productId);

                            if (product != null)
                            {
                                order.Name = product.Name;
                            }

                            _printService.PrintOrder(order, status);
                        }
                        else
                        {
                            Console.WriteLine("Provided option is incorrect, please try any available command \n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Provided option is incorrect, please try any available command \n");
                    }
                }
                else
                {
                    Console.WriteLine("Provided option is incorrect, please try any available command \n");
                }
            } while (true);
        }
    }
}
