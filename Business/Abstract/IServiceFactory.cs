using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Core;

namespace Business.Abstract
{
    public interface IServiceFactory
    {
      
        ICampaignService CreateCampaignService();
        void Release(ICampaignService campaignService);
        IProductService CreateProductService();
        void Release(IProductService productService);
        IPurchaseService CreatePurchaseService();
        void Release(IPurchaseService purchaseService);
        IVendingMachineService CreateVendingMachineServiceService();
        void Release(IVendingMachineService vendingMachineService);
    }
}
