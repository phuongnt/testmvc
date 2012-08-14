using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
    public class ProductRepository
    {
        private static IList<Product> _products;
        private static IList<Product> _products22;

        static ProductRepository()
        {
            _products = new List<Product>();
            _products22 = new List<Product>();

            var random = new Random();

            for (var i = 0; i < 100; i++)
            {
                var product = new Product()
                {
                    Id = i,
                    Name = "Product " + i,
                    Quantity = random.Next(1000)
                };

                _products22.Add(product);
            }

            _products = (from cust in _products22 where cust.Id > 33
                                    select cust).ToList();

        }

        public IQueryable<Product> GetAll()
        {
            return _products.AsQueryable();
        }
    }
}