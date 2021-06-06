using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class VendingMachineManager : IVendingMachineService
    {
        private IProductService _productService;
        private ICampaignService _campaignService;
        private IPurchaseService _purchaseService;
      

        public Dictionary<int, IProductService> VendingMachineItems = new Dictionary<int, IProductService>();


        public VendingMachineManager(IProductService productService,IPurchaseService purchaseService)
        {
            _productService = productService;
            _purchaseService = purchaseService;
            

        }

        public Purchase Money { get; }
        public string NotEnoughMoneyError = "Not enough money in the machine to complete the transaction.";
        public string MessageToUser;

        public double MoneyInMachine
        {
            get { return Money.MoneyInMachine; }
        }

        public void DisplayAllItems()
        {
            Console.WriteLine($"\n\n{"Product".PadRight(7)} {"Price".PadLeft(7)}");
            foreach (var product in _productService.GetAllProducts())
            {
                Console.WriteLine("ID: " + product.ProductId + "\t Product Name: " + product.ProductName +
                                  "\t Price: " + product.Price);
            }
        }

        public bool ItemExists(int itemNumber)
        {
            return _productService.CheckIfProductExists(itemNumber);
        }


        public bool RetreiveItem(int itemNumber)
        {

            if (_productService.CheckIfProductExists(itemNumber)
                && Convert.ToDouble(_purchaseService.GetMoney()) >= _productService.GetProduct(itemNumber).Price)
            {

                // Remove the money
                _purchaseService.RemoveMoney(Convert.ToDouble(_productService.GetProduct(itemNumber).Price));

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}