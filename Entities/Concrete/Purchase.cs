﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Purchase:IEntity
    {
        public decimal MoneyInMachine { get;  set; }
    }
}
