using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;

namespace Business.Concrete
{
    //Ürünle ilgili tüm iş kurallarının yönetildiği yerdir.
    public class ProductManager:IProductService
    {
        private ICampaignService _campaignService;
        private IProductDal _productDal;
        

        public ProductManager(IProductDal productDal,ICampaignService campaignService)
        {
            _productDal = productDal;
            _campaignService = campaignService;
        }

        //Tüm ürünleri listeleyen metot
        public List<Product> GetAllProducts()
        {
            return _productDal.GetAll();
        }

        public bool CheckIfCampaignExists(int productId)
        {
            var result =_campaignService.GetCampaignByProductId(productId);

            if (result == null)
            {
                return false;
            }
            return true;
        }

        public Product AddProductToCart(int productId)
        {
            //var result=_productDal.GetAll();
            //result.Add(productId);
            return _productDal.GetProduct(productId);

        }

        public double EvaluateMinPrice(int productId)
        {
            var campaignList = _campaignService.GetCampaign(productId).ToList();
            double minPrice = campaignList.IndexOf(0);
            for (int i = 0; i < campaignList.Count; i++)
            {
                if (campaignList.IndexOf(i) < minPrice)
                    minPrice = campaignList.IndexOf(i);
            }

            var result = _productDal.GetProduct(productId);
            return result.Price;
        }

        public bool CheckIfProductExists(int productId)
        {
            var result =_productDal.GetProduct(productId);
            if (result != null)
            {
                return true;
            }

            return false;
        }

        public Product GetProduct(int productId)
        {
            return _productDal.GetProduct(productId);
        }
    }
}
