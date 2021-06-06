using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Business.Abstract;
using ConsoleUI;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class SubMenu:ISubMenu
    {

        //private readonly IServiceFactory _serviceFactory;
        private IVendingMachineService _vendingMachineService;
        private ICampaignService _campaignService;
        private IPurchaseService _purchaseService;
        private IProductService _productService;

        List<int> productList = new List<int>();

        ShoppingCart shoppingCart = new ShoppingCart(new CartDal(new CartItem()));
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
               // Console.Clear();
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
                    while (response!="N")
                    {
                        _vendingMachineService.DisplayAllItems();
                        Console.Write(">>> Which product do you want to choose? ");
                        int chosenProductId = Convert.ToInt16(Console.ReadLine());
                        var chosenProduct = _productService.GetProduct(chosenProductId);
                        
                        //ürün mevcut ise
                        if (_vendingMachineService.ItemExists(chosenProductId)&& _purchaseService.GetMoney()>0)
                        {
                            //sepete eklensin
                             shoppingCart.AddToCart(chosenProductId);
                             productList.Add(chosenProductId);
                             
                            //seçilen ürün adedi 2 den fazla ise kampanyalı fiyatlar kontrol edilsin
                            if (productList.Count>2)
                            {
                                //eğer seçilen ürünlerden biri ile ilgili bir kampanya bulunuyorsa
                                var productCampaignPrice = _campaignService.GetProductCampaignPrice(chosenProductId);
                                if (productCampaignPrice.TryGetValue(chosenProductId, out double campaignPrice))
                                {
                                    chosenProduct.Price = campaignPrice;
                                    var minCampaignPrice = _campaignService.EvaluateMinCampaignPrice(productList);
                                    _purchaseService.RemoveMoney(minCampaignPrice);
                                    var result=_purchaseService.GiveChange();
                                    Console.WriteLine(result);
                                    return;
                                }
                            }

                            _purchaseService.RemoveMoney(chosenProduct.Price);
                            var moneyChange = _purchaseService.GiveChange();
                           
                            Console.WriteLine($"Enjoy your {chosenProduct.ProductName}\n");
                            Console.WriteLine("Do you want to adding product? Y/N");
                            
                            response =Console.ReadLine();
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
                        else if (Convert.ToDouble(_purchaseService.GetMoney()) < chosenProduct.Price ||_purchaseService.GetMoney()<0)
                        {
                            Console.WriteLine("There is not enough money!");
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
