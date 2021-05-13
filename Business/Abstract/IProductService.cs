using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        bool CheckIfCampaignExists(int productId);
        Product AddProductToCart(int productId);
        bool CheckIfProductExists(int productId);
        Product GetProduct(int productId);
    }
}
