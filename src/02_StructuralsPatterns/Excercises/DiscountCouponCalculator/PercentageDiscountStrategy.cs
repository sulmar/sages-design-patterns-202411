namespace DiscountCouponCalculator;

public class PercentageDiscountStrategy : IDiscountStrategy
{
    private readonly decimal percentage;
    public PercentageDiscountStrategy(decimal percentage)
    {
        this.percentage = percentage;
    }

    public decimal CalculatePrice(decimal price)
    {
        return price * percentage;
    }
}
