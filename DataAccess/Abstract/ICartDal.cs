using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICartDal
    {
        List<CartItem> GetAll();
        void Add(int id);

    }
}
