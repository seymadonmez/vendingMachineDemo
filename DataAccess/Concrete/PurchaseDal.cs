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

            string message = $"FEED MONEY: ";

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
            string result = string.Empty;
            int quarters = 0;
            int dimes = 0;

            // Logging message "CANDYBARNAME A1"
            string message = $"GIVE CHANGE: ";

            // Logging before: current money in machine
            double before = _purchase.MoneyInMachine;

            if (_purchase.MoneyInMachine > 0)
            {
                while (_purchase.MoneyInMachine > 0)
                {
                    if (_purchase.MoneyInMachine >= 0.25)
                    {
                        quarters++;
                        this.RemoveMoney(0.25);
                    }
                    else if (_purchase.MoneyInMachine >= 0.10)
                    {
                        dimes++;
                        this.RemoveMoney(0.10);
                    }
                    else if (_purchase.MoneyInMachine >= 0.05)
                    {
                        this.RemoveMoney(0.05);
                    }
                }

                result = GetMessage(quarters, dimes);

            }
            else
            {
                result = "No money to return";
            }

            return result;
        }

        public double GetMoney()
        {
            return _purchase.MoneyInMachine;
        }

        private string GetMessage(int quarters, int dimes)
        {
            string quarterString = string.Empty;
            string dS = string.Empty;

            if (quarters > 0)
            {
                quarterString = $"{quarters} quarters";
            }

            if (dimes > 0)
            {
                dS = $"{dimes} dimes";
            }


            string result = $"Your change is ";

            if (quarters > 0 && dimes > 0 )
            {
                result += $"{quarterString}, {dS}";
            }
            else if ((quarters > 0 && dimes > 0) || (quarters > 0))
            {
                result += $"{quarterString} and {dS}";
            }
            else if (dimes > 0 )
            {
                result += $"{dS}";
            }
            else
            {
                result = "No change to give.";
            }

            return result;
        }

    }
}
