using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;

namespace Business.Concrete
{
    //Kampanya ile ilgili tüm iş kuralları yönetilir
    public class CampaignManager:ICampaignService
    {
        private ICampaignDal _campaignDal;

        public CampaignManager(ICampaignDal campaignDal)
        {
            _campaignDal = campaignDal;
        }
        public List<Campaign> GetAll()
        {
            return _campaignDal.GetAll();
        }

        public List<ProductCampaign> GetCampaignByProductId(int productId)
        {
            return _campaignDal.GetCampaignByProductId(productId);
        }

        public void Add(ProductCampaign campaign)
        {
            _campaignDal.Add(campaign);
        }

        public List<int> GetCampaign(int productId)
        {
            return _campaignDal.GetCampaign(productId).ToList();
        }

        public Dictionary<int, double> GetMinCampaignPriceOfProduct(int productId)
        {
            throw new NotImplementedException();
        }

        //kampanyalı fiyatı hesaplayan metot
        public double EvaluateMinCampaignPrice(List<int> productlist)
        {
            foreach (var productId in productlist)
            {
                var result = _campaignDal.GetCampaignByProductId(productId).ToList();
                if (result != null)
                {
                    var campaignPrices = GetProducCampaignList();
                    var products = this.Reverse(campaignPrices);
                    Dictionary<int,double> tempDictionary = new Dictionary<int, double>();
                    
                    var keyR = products.Min(kvp => kvp.Key);
                    var min = products.Aggregate((product, price) => product.Key < price.Key ? product : price).Key;
                    return min;
                }
            }

            return 0;
        }

        public Dictionary<int,double> GetProducCampaignList()
        {
            var result = _campaignDal.GetAllCampaigns().ToList();
            var productCampaigns = result.OrderBy(ProductCampaign => ProductCampaign.CampaignId).GroupBy(ProductCampaign => ProductCampaign.CampaignId);

            Console.WriteLine("Kampanyalar...");
            if (result != null)
            {
                Dictionary<int, double> productCampaign = new Dictionary<int, double>();
                foreach (var campaigns in productCampaigns)
                {
                    Console.WriteLine("{0}. Kampanya :", campaigns.Key);
                    

                    foreach (var campaign in campaigns)
                    {
                        Console.WriteLine("{0} {1}", campaign.ProductId, campaign.CampaignPrice);
                        productCampaign.Add(campaign.ProductId,campaign.CampaignPrice);
                        
                    }
                }

                return productCampaign;

            }

            return null;
        }

        private IDictionary<TValue, List<TKey>> Reverse<TKey, TValue>( IDictionary<TKey, TValue> src)
        {
            var productCampaign=this.GetProducCampaignList();
            //result.GroupBy(r => r.Value)
            //    .ToDictionary(t => t.Key, t => t.Select(r => r.Key).ToList());
            var result = new Dictionary<TValue, List<TKey>>();

            foreach (var pair in src)
            {
                List<TKey> keyList;

                if (!result.TryGetValue(pair.Value, out keyList))
                {
                    keyList = new List<TKey>();
                    result[pair.Value] = keyList;
                }

                keyList.Add(pair.Key);
            }

            return result;

        }

        public bool CheckIfCampaignExists(int productId)
        {
            var result = _campaignDal.GetCampaignByProductId(productId);
            if (result != null)
            {
                return false;
            }

            return true;
        }

        public Dictionary<int, double> GetProductCampaignPrice(int productId)
        {

            Dictionary<int, double> result = _campaignDal.GetCampaignByProductId(productId).ToDictionary(x=>x.ProductId,x=>x.CampaignPrice);
            return result;
        }
    }
}
