using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProxyPattern;

public class DbSet<T> : IQueryable<T>
{
    public Type ElementType => throw new NotImplementedException();

    public Expression Expression => throw new NotImplementedException();

    public IQueryProvider Provider => throw new NotImplementedException();

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

public class ApplicationDbContext
{
    public DbSet<Customer> Customers { get; set; }
}

public class DbCustomerRepository
{
    private readonly ApplicationDbContext context;

    public DbCustomerRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public Customer Get(int id)
    {
        Customer customer = context.Customers.First();

        // Lazy Loading
        Console.WriteLine(customer.HomeAddress.City);

        return customer;
    }
}

// Proxy (wariant klasowy)
public class CustomerProxy : Customer
{
    public override Address HomeAddress 
    { 
        get => base.HomeAddress; 

        set => base.HomeAddress = value; 
    }
}

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual Address HomeAddress { get; set; }
}

public class Address
{
    public string City { get; set; }
    public string Street { get; set; }
}


// Cache Proxy 
// Lazy Proxy 
// Protection Proxy
// Logging Proxy

// Proxy (Pośrednik) - Cache Proxy
// Proxy (wariant obiektowy)

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
