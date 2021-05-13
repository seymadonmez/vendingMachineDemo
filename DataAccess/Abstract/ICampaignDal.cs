using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Entities;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICampaignDal
    {
        List<Campaign> GetAll();

        List<ProductCampaign> GetAllCampaigns();
        //List<ProductCampaign> GetCampaignPrice(int productId);
        List<ProductCampaign> GetCampaignByProductId(int productId);
        void Add(ProductCampaign campaignDetail);
        List<int> GetCampaign(int productId);
        //Dictionary<int, double> GetProductCampaignPrice(int productId);


    }
}
