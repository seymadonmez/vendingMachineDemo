using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;


namespace Business.Concrete
{
    public class MenuManager:IMenuService
    {
        //private readonly IServiceFactory _serviceFactory;

        //public MenuManager(IServiceFactory serviceFactory)
        //{
        //    _serviceFactory = serviceFactory;
        //}
        private ISubMenu _subMenu;
        private IVendingMachineService _vendingMachineService;

        public MenuManager(ISubMenu subMenu,IVendingMachineService vendingMachineService)
        {
            _subMenu = subMenu;
            _vendingMachineService = vendingMachineService;
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
                    _vendingMachineService.DisplayAllItems();
                    _subMenu.Display(); 
                }
                else if (input == "2")
                {
                    //SubMenu subMenu = new SubMenu(new VendingMachineManager(
                    //        new ProductManager(new ProductDal(),new CampaignManager(new CampaignDal())),
                    //        new PurchaseManager(new PurchaseDal(new Purchase())));
                    _subMenu.Display();
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
            Console.WriteLine("WELCOME TO THE VENDING MACHINE!");
        }

    }
}
