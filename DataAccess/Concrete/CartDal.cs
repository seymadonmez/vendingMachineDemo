using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class CartDal:ICartDal
    {
        private List<CartItem> _cartItems;
        public CartDal(CartItem cartItem)
        {
            _cartItems = new List<CartItem>();
        }
        public List<CartItem> GetAll()
        {
            return _cartItems;
        }

        public void Add(int id)
        {
            CartItem tempCartItem = new CartItem(){ProductId = id,Quantity =+1};

            //tempCartItem.Quantity++;
            _cartItems.Add(tempCartItem);
        
        }

        
    }
}
