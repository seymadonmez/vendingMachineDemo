using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Menu

    {

        private readonly IServiceFactory _serviceFactory;


        public Menu(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public void Display()
        {

            PrintHeader();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("1] Display Vending Machine Items");
                Console.WriteLine("2] Purchase");
                Console.WriteLine("Q] Quit");

                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Displaying Items");
                    _serviceFactory.CreateVendingMachineServiceService().DisplayAllItems();
                }
                else if (input == "2")
                {
                    SubMenu subMenu = new SubMenu(new VendingMachineManager(
                        new CampaignManager(new CampaignDal()),
                        new PurchaseManager(new PurchaseDal(new Purchase())),
                        new ProductManager(new ProductDal(),new CampaignManager(new CampaignDal()))),
                        new CampaignManager(new CampaignDal()),new PurchaseManager(new PurchaseDal(new Purchase())),new ProductManager(new ProductDal(),new CampaignManager(new CampaignDal())));
                    subMenu.Display();
                }
                else if (input.ToUpper() == "Q")
                {
                    Console.WriteLine("Quitting");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }

                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void PrintHeader()
        {
            Console.WriteLine("WELCOME TO THE BEST VENDING MACHINE EVER!!!! (Distant crowd roar)");
        }
    }
}
