namespace DiscountCouponCalculator;

public class FixedDiscountStrategy : IDiscountStrategy
{
    private readonly decimal amount;

    public FixedDiscountStrategy(decimal amount)
    {
        this.amount = amount;
    }

    public decimal CalculatePrice(decimal price)
    {
        return price - amount;
    }
}
