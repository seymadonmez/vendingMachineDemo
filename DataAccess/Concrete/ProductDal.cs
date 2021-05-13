using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete
{
    public class ProductDal:IProductDal
    {
        private List<Product> _products;

        public ProductDal()
        {
            _products = new List<Product>()
            {
                new Product{ProductId = 1,ProductName = "Dimes",Price = 4.2},
                new Product{ProductId = 2,ProductName = "Coca Cola",Price = 8},
                new Product{ProductId = 3,ProductName = "Sprite",Price = 7.4},
                new Product{ProductId = 4,ProductName = "Crackers",Price = 2.9},
                new Product{ProductId = 5,ProductName = "Pınar Su",Price = 1},
                new Product{ProductId = 6,ProductName = "Fanta",Price = 3.7},
                new Product{ProductId = 7,ProductName = "Popkek",Price = 0.8},
                new Product{ProductId = 8,ProductName = "Çubuk Kraker",Price = 1.2},
                new Product{ProductId = 9,ProductName = "Enerji İçeceği",Price = 6.4},
                new Product{ProductId = 10,ProductName = "Kahve",Price = 2},
                new Product{ProductId = 11,ProductName = "Soğuk Çay",Price = 4.8},
                new Product{ProductId = 12,ProductName = "Cips",Price = 3.1},

            };
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetProduct(int id)
        {
            return _products.Find(p => p.ProductId == id);
        }

    }
}
