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
            _purchase = new Purchase() {MoneyInMachine = 100.0M};
        }

        

        public bool AddMoney(string amount)
        {
            if (!decimal.TryParse(amount, out decimal amountInserted))
            {
                amountInserted = 0M;
                return false;
            }

            string message = $"FEED MONEY: ";

            // Add the money
            _purchase.MoneyInMachine += amountInserted;
            return true;

        }

        public bool RemoveMoney(decimal amountToRemove)
        {
            if (_purchase.MoneyInMachine <= 0)
            {
                return false;
            }

            _purchase.MoneyInMachine -= amountToRemove;
            return true;
        }

        public string GiveChange()
        {
            string result = string.Empty;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            // Logging message "CANDYBARNAME A1"
            string message = $"GIVE CHANGE: ";

            // Logging before: current money in machine
            decimal before = _purchase.MoneyInMachine;

            if (_purchase.MoneyInMachine > 0)
            {
                while (_purchase.MoneyInMachine > 0)
                {
                    if (_purchase.MoneyInMachine >= 0.25M)
                    {
                        quarters++;
                        this.RemoveMoney(0.25M);
                    }
                    else if (_purchase.MoneyInMachine >= 0.10M)
                    {
                        dimes++;
                        this.RemoveMoney(0.10M);
                    }
                    else if (_purchase.MoneyInMachine >= 0.05M)
                    {
                        nickels++;
                        this.RemoveMoney(0.05M);
                    }
                }

                result = GetMessage(quarters, dimes, nickels);

            }
            else
            {
                result = "No money to return";
            }

            return result;
        }

        public decimal GetMoney()
        {
            return _purchase.MoneyInMachine;
        }

        private string GetMessage(int quarters, int dimes, int nickels)
        {
            string quarterString = string.Empty;
            string dS = string.Empty;
            string nS = string.Empty;

            if (quarters > 0)
            {
                quarterString = $"{quarters} quarters";
            }

            if (dimes > 0)
            {
                dS = $"{dimes} dimes";
            }

            if (nickels > 0)
            {
                nS = $"{nickels} nickels";
            }

            string result = $"Your change is ";

            if (quarters > 0 && dimes > 0 && nickels > 0)
            {
                result += $"{quarterString}, {dS}, and {nS}";
            }
            else if ((quarters > 0 && dimes > 0) || (quarters > 0 && nickels > 0))
            {
                result += $"{quarterString} and {dS}{nS}";
            }
            else if (dimes > 0 && nickels > 0)
            {
                result += $"{dS} and {nS}";
            }
            else if (quarters > 0 || dimes > 0 || nickels > 0)
            {
                result += $"{quarterString}{dS}{nS}";
            }
            else
            {
                result = "No change to give.";
            }

            return result;
        }

    }
}
