using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProxyPattern
{
    // Proxy (Pośrednik)
    public class CacheProductRepository : IProductRepository
    {
        // Real Subject
        private IProductRepository _repository;

        private IDictionary<int, Product> products;

        public CacheProductRepository(IProductRepository productRepository)
        {
            products = new Dictionary<int, Product>();

            _repository = productRepository;
        }

        public void Add(Product product)
        {
            products.Add(product.Id, product);
        }

        public Product Get(int id)
        {
            if (products.TryGetValue(id, out Product product))
            {
                product.CacheHit++;

                return product;
            }
            else
            {
                product = _repository.Get(id); // Użycie RealSubject

                if (product != null)
                {
                    Add(product);
                }

                return product;
            }

        }

    }
}
