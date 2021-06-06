using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class CartItem:IEntity
    {

        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
