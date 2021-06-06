using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using Entities.Concrete;
using Ninject;


namespace ConsoleUI
{
    class Program
    {
        private static readonly IServiceFactory _serviceFactory;
       
        static void Main(string[] args)
        {

            //IKernel kernal = new StandardKernel(new BusinessModule());
            //IServiceFactory serviceFactory = new ServiceFactory(kernal);
            //serviceFactory.CreateCampaignService();
            //serviceFactory.CreatePurchaseService();
            //serviceFactory.CreateVendingMachineServiceService();
            ////var kernel = new StandardKernel();
            ////kernel.Load(Assembly.GetExecutingAssembly());
            //ServiceFactory.Handle();

            ICampaignService campaignService = new CampaignManager(new CampaignDal());
            IProductService productService = new ProductManager(new ProductDal(), campaignService);
            IPurchaseService purchaseService = new PurchaseManager(new PurchaseDal(new Purchase()));
            IVendingMachineService vendingMachineService = new VendingMachineManager(productService, purchaseService);
            ISubMenu subMenu = new SubMenu(vendingMachineService,campaignService,purchaseService,productService);
            IMenuService menuService = new MenuManager(subMenu, vendingMachineService);
           

            menuService.Display();
        

        
            menuService.Display();





        
            ICampaignService camps
                = new CampaignManager(new CampaignDal());
            camps.GetProducCampaignList();
            camps.EvaluateMinCampaignPrice(new List<int>() {1, 2});
            Console.WriteLine("Ürün seçiniz");
            Console.WriteLine("---------------Ürünler---------------");
            foreach (var product in productService.GetAllProducts())
            {
                Console.WriteLine("ID: " + product.ProductId + "\tÜrün Adı: " + product.ProductName + "\tFiyat: " + product.Price);
            }

            int chosenProductId = Convert.ToInt16(Console.ReadLine());

            productService.AddProductToCart(chosenProductId);

            if (productService.CheckIfCampaignExists(chosenProductId))
            {

            }

            productService.CheckIfCampaignExists(3);
        }

    }

}
