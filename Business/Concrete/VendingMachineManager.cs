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

        public VendingMachineManager(IProductService productService,ICampaignService campaignService,IPurchaseService purchaseService)
        {
            _productService = productService;
            _campaignService = campaignService;
            _purchaseService = purchaseService;
        }

        public VendingMachineManager(ICampaignService campaignService, IPurchaseService purchaseService,
            IProductService productService)
        {
            _campaignService = campaignService;
            _purchaseService = purchaseService;
            _productService = productService;

        }

        public Purchase Money { get; }
        public string NotEnoughMoneyError = "Not enough money in the machine to complete the transaction.";
        public string MessageToUser;

        public decimal MoneyInMachine
        {
            get { return Money.MoneyInMachine; }
        }

        public void DisplayAllItems()
        {
            Console.WriteLine($"\n\n{"Product".PadRight(47)} {"Price".PadLeft(7)}");
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
            // If the item exists (not Q1 or something like that)
            // and we can remove the item
            // and we have more money in the machine than the price
            if (_productService.CheckIfProductExists(itemNumber)
                && Convert.ToDouble(_purchaseService.GetMoney()) >= _productService.GetProduct(itemNumber).Price)
            {

                // Remove the money
                _purchaseService.RemoveMoney(Convert.ToDecimal(_productService.GetProduct(itemNumber).Price));

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}