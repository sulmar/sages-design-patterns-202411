using System;

namespace NullObjectPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Null Object Pattern!");

        IProductRepository productRepository = new FakeProductRepository();

        // Pobierz produkt z ID 1
        ProductBase product1 = productRepository.Get(1);
        product1.RateId(3);

        // Pobierz produkt z ID 2
        ProductBase product2 = productRepository.Get(2);
        product2.RateId(5);

        // Pobierz produkt z ID 999 (nieistniejący)
        ProductBase product3 = productRepository.Get(999);
        product3.RateId(7);

    }
}

public interface IProductRepository
{
    ProductBase Get(int id);
}

public class FakeProductRepository : IProductRepository
{
    // Symulacja pobierania z repozytorium
    public ProductBase Get(int id) =>
        id switch
        {
            1 => new Product(),// Realny produkt
            2 => new Product(),// Realny produkt
            _ => ProductBase.Null,// Null Object
        };
}

// Abstract Object
public abstract class ProductBase
{
    protected int rate;

    public abstract void RateId(int rate);

    public static readonly ProductBase Null = new NullProduct();

    // Null Object
    private class NullProduct : ProductBase
    {
        public override void RateId(int rate)
        {
            // nic nie rób
            Console.WriteLine("Cannot rate a null product.");
        }
    }
}

// Real Object
public class Product : ProductBase
{
    private int rate;

    public override void RateId(int rate)
    {
        this.rate = rate;
        Console.WriteLine($"Product rated with {rate}.");
    }

}
