using System;

namespace StrategyPattern;

// Abstract Strategy
public interface IDiscountStrategy
{
    bool CanDiscount(DateTime dateTime);
    decimal Discount(decimal price);
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

public class HappyHoursDiscountStrategy(TimeSpan from, TimeSpan to, decimal percentage = 0.10m) : IDiscountStrategy
{
    public bool CanDiscount(DateTime OrderDate) => OrderDate.TimeOfDay >= from && OrderDate.TimeOfDay <= to;
    public decimal Discount(decimal price) => price * percentage;
}

public class BlackFridayDiscountStrategy(DateTime specialDate, decimal percentage = 0.20m) : IDiscountStrategy
{
    public bool CanDiscount(DateTime OrderDate) => OrderDate == specialDate;
    public decimal Discount(decimal price) => price * percentage; // 20% zniżki
}

public class NoDiscountStrategy : IDiscountStrategy
{
    public bool CanDiscount(DateTime dateTime) => true;
    public decimal Discount(decimal price) => 0;
}

public class ShoppingCart
{
    private decimal _price;

    public DateTime OrderDate { get; set; }

    public IDiscountStrategy DiscountStrategy { get; set; }


    public ShoppingCart(decimal price)
    {
        _price = price;

        DiscountStrategy = new NoDiscountStrategy();
    }

    // Obliczanie ceny na podstawie zniżki
    public decimal CalculateTotalPrice()
    {
        if (DiscountStrategy.CanDiscount(OrderDate))
        {
            return _price - DiscountStrategy.Discount(_price);
        }
        else
        {
            return _price;
        }


    }
}