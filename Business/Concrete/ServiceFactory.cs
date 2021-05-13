using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Ninject;

namespace Business.Concrete
{
    public class ServiceFactory:IServiceFactory
    {
        private readonly IServiceFactory serviceFactory;

        public ServiceFactory(IKernel kernel)
        {
            serviceFactory = kernel.Get<IServiceFactory>();
            kernel.Dispose();
        }
        public ICampaignService CreateCampaignService()
        {
            return new CampaignManager(new CampaignDal());
        }

        public void Release(ICampaignService campaignService)
        {
            this.CreateCampaignService();
        }

        public IProductService CreateProductService()
        {
            return new ProductManager(new ProductDal(),new CampaignManager(new CampaignDal()));
        }

        public void Release(IProductService productService)
        {
             this.CreateProductService();
            
        }

        public IPurchaseService CreatePurchaseService()
        {
            return new PurchaseManager(new PurchaseDal(new Purchase()));
        }

        public void Release(IPurchaseService purchaseService)
        {
             this.CreatePurchaseService();
            
        }

        public IVendingMachineService CreateVendingMachineServiceService()
        {
            return null;
        }

        public void Release(IVendingMachineService vendingMachineService)
        {
            CreateVendingMachineServiceService();
        }
        private bool disposedValue = false;

        
    }
}
