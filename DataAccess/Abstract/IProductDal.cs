using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll();

        Product GetProduct(int productId);
    }
}
