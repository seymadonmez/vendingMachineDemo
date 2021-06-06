using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class PurchaseDal:IPurchaseDal
    {
        private Purchase _purchase;

        public PurchaseDal(Purchase purchase)
        {
            _purchase = new Purchase() {MoneyInMachine = 0};
        }


        public bool AddMoney(string amount)
        {
            if (!double.TryParse(amount, out double amountInserted))
            {
                amountInserted = 0;
                return false;
            }

            // Add the money
            _purchase.MoneyInMachine += amountInserted;
            return true;

        }

        public double RemoveMoney(double amountToRemove)
        {
            if (_purchase.MoneyInMachine <= 0)
            {
                return -1;
            }

            _purchase.MoneyInMachine -= amountToRemove;
            return _purchase.MoneyInMachine;
        }

        public string GiveChange()
        {
            
            if (_purchase.MoneyInMachine > 0)
            {
                return _purchase.MoneyInMachine.ToString();

            }
            return  "No money to return";
        }

        public double GetMoney()
        {
            return _purchase.MoneyInMachine;
        }

    }
}
