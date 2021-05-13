using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities;

namespace ConsoleUI
{
    public class ShoppingCart
    {
        public int printY;
        public List<Product> _productList;
        private IProductService _productService = new ProductManager(new ProductDal(),new CampaignManager(new CampaignDal()));

        public ShoppingCart()
        {
            _productList = new List<Product>();
        }

        public void Display()
        {
            if (_productList.Count == 0)
                Console.WriteLine("------------------ EMPTY CART------------------ ");

            foreach (var prod in _productList)
                Console.WriteLine(prod.ProductName + " value: " + prod.Price);
        }

        public void AddProduct(Product product)
        {
            _productService.AddProductToCart(product.ProductId);
        }
    }
}
