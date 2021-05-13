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
            ////var mailSender = kernel.Get<IServiceFactory>();

            //var formHandler = new ServiceFactory(mailSender);
            //ServiceFactory.Handle();

            //Menu menu = new Menu(_serviceFactory);
            //menu.Display();

           




            List<Product> productList = new List<Product>();
            ProductManager productManager = new ProductManager(new ProductDal(), new CampaignManager(new CampaignDal()));

            ICampaignService camps
                = new CampaignManager(new CampaignDal());
            camps.GetProducCampaignList();
            camps.EvaluateCampaignPrice(new List<int>() {1, 2});
            Console.WriteLine("Ürün seçiniz");
            Console.WriteLine("---------------Ürünler---------------");
            foreach (var product in productManager.GetAllProducts())
            {
                Console.WriteLine("ID: " + product.ProductId + "\tÜrün Adı: " + product.ProductName + "\tFiyat: " + product.Price);
            }

            int chosenProductId = Convert.ToInt16(Console.ReadLine());

            productManager.AddProductToCart(chosenProductId);

            if (productManager.CheckIfCampaignExists(chosenProductId))
            {

            }




            CampaignManager campaignManager = new CampaignManager(new CampaignDal());

            productManager.CheckIfCampaignExists(3);
        }


        
    }

}
