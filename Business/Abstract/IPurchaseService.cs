using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPurchaseService
    {
        decimal GetMoney();
        bool AddMoney(string amount);
        bool RemoveMoney(decimal amountToRemove);
        string GiveChange();
    
    }
}
