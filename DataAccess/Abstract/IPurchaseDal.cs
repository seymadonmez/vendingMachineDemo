using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPurchaseDal
    {
        bool AddMoney(string amount);
        double RemoveMoney(double amountToRemove);
        string GiveChange();
        double GetMoney();
    }
}
