using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace Business.Concrete
{
    public class  BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IServiceFactory>().ToFactory();
           

            Bind<ICampaignService>().To<CampaignManager>().InSingletonScope();
            Bind<ICampaignDal>().To<CampaignDal>().InSingletonScope();

            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<ProductDal>().InSingletonScope();

            Bind<IPurchaseService>().To<PurchaseManager>().InSingletonScope();
            Bind<IPurchaseDal>().To<PurchaseDal>().InSingletonScope();

            Bind<IVendingMachineService>().To<VendingMachineManager>().InSingletonScope();

            Bind<IVendingMachineService>().To<VendingMachineManager>().InSingletonScope();


        }
    }
}
