using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using Entities.Concrete;

namespace ConsoleUI
{
    public class ShoppingCart
    {
        private ICartDal _cartDal;

 
        private IProductService _productService = new ProductManager(new ProductDal(),new CampaignManager(new CampaignDal()));

        public ShoppingCart(ICartDal cartDal)
        {
            _cartDal = cartDal;
          
        }

        public void Display()
        {
            if (_cartDal.GetAll().Count == 0)
                Console.WriteLine("------------------ EMPTY CART------------------ ");

            foreach (var prod in _cartDal.GetAll())
                Console.WriteLine(prod.ProductId + " value: " + prod.Quantity);
        }

        public void AddProduct(Product product)
        {
            _productService.AddProductToCart(product.ProductId);
        }
        public void AddToCart(int id)
        {
            var cartItem = new CartItem() {ProductId = id,Quantity =1 };
            cartItem.Quantity++;
        }

        public List<CartItem> GetCartItems()
        {
            return _cartDal.GetAll();
        }
    }
}
