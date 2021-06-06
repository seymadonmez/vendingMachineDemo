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

        public void AddToCart(int id)
        {
           _cartDal.Add(id);

        }

        public List<CartItem> GetCartItems()
        {
            return _cartDal.GetAll();
        }
    }
}
