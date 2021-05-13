using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PurchaseManager:IPurchaseService
    {
        private IPurchaseDal _purchaseDal;

        public PurchaseManager(IPurchaseDal purchaseDal)
        {
            _purchaseDal = purchaseDal;
        }
        public decimal GetMoney()
        {
            return _purchaseDal.GetMoney();
        }

        public bool AddMoney(string amount)
        {
            var result = _purchaseDal.AddMoney(amount);
            if (result != null)
            {
                return false;
            }
            return true;
        }

        public bool RemoveMoney(decimal amountToRemove)
        {
            var result = _purchaseDal.RemoveMoney(amountToRemove);
            if (result != null)
            {
                return false;
            }
            return true; 
        }

        public string GiveChange()
        {
            return _purchaseDal.GiveChange();
        }
    }
}
