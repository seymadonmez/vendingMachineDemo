using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPurchaseService
    {
        double GetMoney();
        bool AddMoney(string amount);
        double RemoveMoney(double amountToRemove);
        string GiveChange();
    
    }
}
