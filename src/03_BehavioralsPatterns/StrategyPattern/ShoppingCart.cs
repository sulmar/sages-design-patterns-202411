using System;

namespace StrategyPattern;

// Abstract Strategy
public interface IDiscountStrategy
{    
    decimal Discount(decimal price);
}

public interface ICanDiscountStrategy
{
    bool CanDiscount(DateTime dateTime);
}

public abstract class DelegateDiscountStrategy : IDiscountStrategy
{
    private readonly Func<DateTime, bool> _canDiscount;
    private readonly Func<decimal, decimal> _discount;

    protected DelegateDiscountStrategy(Func<DateTime, bool> canDiscount, Func<decimal, decimal> discount)
    {
        _canDiscount = canDiscount;
        _discount = discount;
    }

    public bool CanDiscount(DateTime OrderDate) => _canDiscount.Invoke(OrderDate);
    public decimal Discount(decimal price) => _discount.Invoke(price);
}

public class HappyHoursDelegateDiscountStrategy : DelegateDiscountStrategy, IDiscountStrategy
{ 
    public HappyHoursDelegateDiscountStrategy(TimeSpan from, TimeSpan to, decimal percentage = 0.90m)
        : base(
        OrderDate => OrderDate.TimeOfDay >= from && OrderDate.TimeOfDay <= to,
        price => price * percentage)
    {
    }
}

public class PercentageDiscountStrategy(decimal percentage = 0.10m) : IDiscountStrategy
{   
    public decimal Discount(decimal price) => price * percentage;
}

public class FixedDiscountStrategy(decimal amount) : IDiscountStrategy
{
    public decimal Discount(decimal price) => amount;
}

public class NoDiscountStrategy : IDiscountStrategy
{
    public decimal Discount(decimal price) => 0;
}

public class AlwaysCanDiscountStrategy : ICanDiscountStrategy
{
    public bool CanDiscount(DateTime dateTime) => true;
}

public class HappyHoursCanDiscountStrategy(TimeSpan from, TimeSpan to) : ICanDiscountStrategy
{
    public bool CanDiscount(DateTime OrderDate) => OrderDate.TimeOfDay >= from && OrderDate.TimeOfDay <= to;    
}

public class BlackFridayCanDiscountStrategy(DateTime specialDate) : ICanDiscountStrategy
{
    public bool CanDiscount(DateTime OrderDate) => OrderDate == specialDate;    
}



// Most
public class ShoppingCart
{
    private decimal _price;

    public DateTime OrderDate { get; set; }

    public ICanDiscountStrategy CanDiscountStrategy { get; set; }
    public IDiscountStrategy DiscountStrategy { get; set; }


    public ShoppingCart(decimal price)
    {
        _price = price;

        CanDiscountStrategy = new AlwaysCanDiscountStrategy();
        DiscountStrategy = new NoDiscountStrategy();
    }

    // Obliczanie ceny na podstawie zniżki
    public decimal CalculateTotalPrice()
    {
        if (CanDiscountStrategy.CanDiscount(OrderDate))
        {
            return _price - DiscountStrategy.Discount(_price);
        }
        else
        {
            return _price;
        }


    }
}