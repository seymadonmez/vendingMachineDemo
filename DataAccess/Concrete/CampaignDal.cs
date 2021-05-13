using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class CampaignDal:ICampaignDal
    {
        
        private List<Campaign> _campaigns;
        private List<ProductCampaignDto> _productCampaignDtos;
        private List<ProductCampaign> _productCampaigns;
      
        public CampaignDal()
        {
           
            _campaigns = new List<Campaign>()
            {
                new Campaign{CampaignId = 1,CampaignName = "Dimes-Coca Cola"},
                new Campaign{CampaignId = 2,CampaignName = "Sprite-Popkek-Soğuk Çay"},
                new Campaign{CampaignId = 3,CampaignName = "Enerji İçeçeği- Crackers"},
                new Campaign{CampaignId = 4,CampaignName = "Dimes - Crackers"},
                new Campaign{CampaignId = 5,CampaignName = "Dimes - Popkek"},
                new Campaign{CampaignId = 6,CampaignName = "Popkek - Soğuk Çay"},
                new Campaign{CampaignId = 7,CampaignName = "Sprite - Dimes"},
                new Campaign{CampaignId = 8,CampaignName = "Crackers- Enerji İçeceği - Soğuk Çay "},
                new Campaign{CampaignId = 9,CampaignName = "Popkek - Sprite"}

            };

            _productCampaignDtos = new List<ProductCampaignDto>()
            {
                new ProductCampaignDto{CampaignId = 1, ProductIdList = new List<int>{1,2},CampaignPrice = new Dictionary<int, double>(){{ 1, 4 },{2,6}}},
                new ProductCampaignDto{CampaignId = 2, ProductIdList = new List<int>(){3,7,11},CampaignPrice =new Dictionary<int, double>() {{ 3, 5 },{7,0.5},{11,2}}},
                new ProductCampaignDto{CampaignId = 3, ProductIdList = new List<int>(){9,4},CampaignPrice =new Dictionary<int, double>(){{ 9, 6 },{4,2}}},
                new ProductCampaignDto{CampaignId = 4, ProductIdList = new List<int>(){1,4},CampaignPrice =new Dictionary<int, double>() {{ 1, 3 },{4,1.8}}},
                new ProductCampaignDto{CampaignId = 5, ProductIdList = new List<int>(){1,7},CampaignPrice = new Dictionary<int, double>(){{ 1, 3.2 },{7,0.7}}},
                new ProductCampaignDto{CampaignId = 6, ProductIdList = new List<int>(){7,11},CampaignPrice = new Dictionary<int, double>(){{ 7, 0.4 },{11,3.9}}},
                new ProductCampaignDto{CampaignId = 7, ProductIdList = new List<int>(){3,1},CampaignPrice =new Dictionary<int, double>(){{ 3, 5.8 },{1,2.9}}},
                new ProductCampaignDto{CampaignId = 8, ProductIdList = new List<int>(){4,9,11},CampaignPrice =new Dictionary<int, double>() {{ 4, 2.1 },{9,5.4},{11,3.7}}},
                new ProductCampaignDto{CampaignId = 9, ProductIdList = new List<int>(){3,1},CampaignPrice =new Dictionary<int, double>() {{ 7, 0 },{3,7}}}

            };
            _productCampaigns = new List<ProductCampaign>()
            {
                new ProductCampaign() {Id = 1,CampaignId = 1, ProductId = 1, CampaignPrice = 4},
                new ProductCampaign() {Id = 2,CampaignId = 1, ProductId = 2, CampaignPrice = 6},
                new ProductCampaign() {Id = 3,CampaignId = 2, ProductId = 3, CampaignPrice = 5},
                new ProductCampaign() {Id = 4,CampaignId = 2, ProductId = 7, CampaignPrice = 0.5},
                new ProductCampaign() {Id = 4,CampaignId = 2, ProductId = 11, CampaignPrice = 2}

            };

        }
        public List<Campaign> GetAll()
        {
            return _campaigns;
        }
        public List<ProductCampaign> GetAllCampaigns()
        {
            return _productCampaigns;
        }

        public List<ProductCampaign> GetAllProductCampaigns()
        {
            return _productCampaigns;
        }

        public List<ProductCampaign> GetCampaignByProductId(int productId)
        {
            return _productCampaigns.Where(c => c.ProductId==productId).ToList();
        }

        public void Add(ProductCampaign campaignDetail)
        {
            _productCampaigns.Add(campaignDetail);
        }

        public List<int> GetCampaign(int productId)
        {
            var result= _productCampaigns.FindAll(c => c.ProductId == productId);
            List<int> resuList = new List<int>();
            foreach (var p in result)
            {
                resuList.Add(p.ProductId);
            }

            return resuList;
            //return _productCampaigns.Find(c => c.ProductIdList.Contains(productId)).ProductIdList;
        }

        //public Dictionary<int, double> GetProductCampaignPrice(int productId)
        //{
        //    double campaignPrice = 0;

        //    Dictionary<int, double> tempDictionary = new Dictionary<int, double>();

        //    for (int i = 0; i < _productCampaigns.Count; i++)
        //    {
        //        if (_productCampaigns.FindAll(c => c.CampaignPrice.TryGetValue(productId, out campaignPrice)) != null)
        //        {
        //                KeyValuePair<int, double> kvp = new KeyValuePair<int, double>();
        //                kvp.Key = productId;
        //                kvp.Value = campaignPrice;
        //                return kvp;
        //        }
        //    }
        //    throw new NotImplementedException();
        //}

        //public List<ProductCampaign> GetCampaignPrice(int productId)
        //{


        //    return _productCampaigns.Find(c => List<int> listNumber = c.CampaignPrice.Select(kvp => kvp.Key).ToList());

        //    List<int> keys = new List<int>(_productCampaigns.SelectMany(c => c.CampaignPrice.Keys));
        //    foreach (int key in keys)
        //    {
        //        Console.WriteLine(key);
        //    }

        //    var result = _productCampaigns.Select(c => c.CampaignPrice.ContainsKey(productId)).Count();
        //    if (result > 0)
        //    {
        //        double value;
        //        return _productCampaigns.Where(c => c.CampaignPrice.TryGetValue(productId, out value)).ToList();
        //    }

        //    return null;

        //    return
        //    foreach (KeyValuePair<int, double> campaign in _productCampaigns.))
        //    {
        //        Console.WriteLine("Key: {0}, Value: {1}", author.Key, author.Value);
        //    }
        //    var result1 = _productCampaigns.Select(data => new { Key = data.CampaignPrice.Keys, Value = data.CampaignPrice.Values });
        //    Dictionary<int, double> dictionary = result1.ToDictionary(pair => pair.Key, pair => pair.Value);
        //    if (result != null)
        //    {

        //    }

        //}

        
    }
}
