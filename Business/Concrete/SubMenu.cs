using System;
using Business.Abstract;
using ConsoleUI;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class SubMenu
    {

        //private readonly IServiceFactory _serviceFactory;
        private IVendingMachineService _vendingMachineService;
        private ICampaignService _campaignService;
        private IPurchaseService _purchaseService;
        private IProductService _productService;
        public SubMenu(IVendingMachineService vendingMachineService, ICampaignService campaignService,IPurchaseService purchaseService,IProductService productService)
        {
            _vendingMachineService = vendingMachineService;
            _campaignService = campaignService;
            _purchaseService = purchaseService;
            _productService = productService;
            //_serviceFactory = serviceFactory;
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Please choose from the following options:");
                Console.WriteLine("1] >> Feed Money");
                Console.WriteLine("2] >> Select Product");
                Console.WriteLine("3] >> Finish Transaction");
                Console.WriteLine("Q] >> Return to Main Menu");
                
                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine(">>> How much do you want to insert?");
                    while (true)
                    {
                        Console.Write("1, 2, 5, 10 TL? ");
                        string amountToSubmit = Console.ReadLine();
                        if (amountToSubmit == "1"
                            || amountToSubmit == "2"
                            || amountToSubmit == "5"
                            || amountToSubmit == "10")
                        {
                            if (!_purchaseService.AddMoney(amountToSubmit))
                            {
                                Console.WriteLine("Insert a valid amount.");
                            }
                            else
                            {
                                Console.WriteLine($"Money in Machine: {_purchaseService.GetMoney().ToString("C")}");
                                break;
                            }
                        }
                    }

                }
                else if (input == "2")
                {
                    Console.WriteLine("Do you want to adding product? Y/N");
                    string response = Console.ReadLine().ToUpper();
                    while (input!="Y")
                    {
                        _vendingMachineService.DisplayAllItems();
                        Console.Write(">>> What item do you want? ");
                        int chosenProductId = Convert.ToInt16(Console.ReadLine());
                        var chosenProduct = _productService.GetProduct(chosenProductId);

                        if (_vendingMachineService.ItemExists(chosenProductId) && _vendingMachineService.RetreiveItem(chosenProductId))
                        {
                            if (_campaignService.GetProductCampaignPrice(chosenProductId) != null)
                            {

                                var result = _campaignService.GetProductCampaignPrice(chosenProductId)
                                    .TryGetValue(chosenProductId, out double campaignPrice);
                                chosenProduct.Price = campaignPrice;
                            }
                            Console.WriteLine($"Enjoy your {chosenProduct.ProductName}\n");
                            Console.WriteLine("Do you want to adding product? Y/N");
                            
                                ShoppingCart shoppingCart = new ShoppingCart(new CartDal(new CartItem()));
                                shoppingCart.AddToCart(chosenProductId);
                                break;
                        }
                        else if (!_vendingMachineService.ItemExists(chosenProductId))
                        {
                            Console.Clear();
                            Console.WriteLine("**INVALID ITEM**");
                        }
                        else if (_vendingMachineService.ItemExists(chosenProductId) && Convert.ToDouble(_purchaseService.GetMoney()) > chosenProduct.Price)
                        {
                            Console.WriteLine("Product does not exists");
                        }
                        else if (Convert.ToDouble(_purchaseService.GetMoney()) < chosenProduct.Price)
                        {
                            Console.WriteLine("Not enourh money");
                            break;
                        }
                    }
                }
                else if (input == "3")
                {
                    Console.WriteLine("Finishing Transaction");
                    Console.WriteLine(_purchaseService.GiveChange());
                }
                else if (input.ToUpper() == "Q")
                {
                    Console.WriteLine("Returning to main menu");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }

                Console.ReadLine();
            }
        }
        
    }
}
