using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVendingMachineService
    {
        void DisplayAllItems();
        bool ItemExists(int itemNumber);
        bool RetreiveItem(int itemNumber);
    }
}
