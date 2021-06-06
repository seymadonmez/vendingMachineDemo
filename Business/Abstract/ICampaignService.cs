using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICampaignService
    {
        List<Campaign> GetAll();
        List<ProductCampaign> GetCampaignByProductId(int productId);
        void Add(ProductCampaign campaign);
        List<int> GetCampaign(int productId);
        //List<ProductCampaignDto> GetCampaignByPrice(int productId);
        Dictionary<int, double> GetMinCampaignPriceOfProduct(int productId);
        bool CheckIfCampaignExists(int productId);
        double EvaluateMinCampaignPrice(List<int> productlist);
        Dictionary<int, double> GetProductCampaignPrice(int productId);
        Dictionary<int, double> GetProducCampaignList();
    }
}
