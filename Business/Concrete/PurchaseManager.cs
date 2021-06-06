using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PurchaseManager : IPurchaseService
    {
        private IPurchaseDal _purchaseDal;

        public PurchaseManager(IPurchaseDal purchaseDal)
        {
            _purchaseDal = purchaseDal;
        }
      

        public bool AddMoney(string amount)
        {
            var result = _purchaseDal.AddMoney(amount);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public double RemoveMoney(double amountToRemove)
        {
            var result = _purchaseDal.RemoveMoney(amountToRemove);
            if (result >0)
            {
                return result;
            }
            return -1; 
        }

        public string GiveChange()
        {
            return _purchaseDal.GiveChange();
        }

        public double GetMoney()
        {
            return _purchaseDal.GetMoney();
        }
    }
}
