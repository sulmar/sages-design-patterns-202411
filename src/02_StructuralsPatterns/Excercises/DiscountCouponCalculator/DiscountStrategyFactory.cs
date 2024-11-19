namespace DiscountCouponCalculator;

public class DiscountStrategyFactory : IDiscountStrategyFactory
{      
    public IDiscountStrategy Create(string discountCode)
    {
        if (string.IsNullOrEmpty(discountCode))
        {
            return new PercentageDiscountStrategy(1);
        }
        else if (discountCode == "SAVE10NOW")
        {
            return new PercentageDiscountStrategy(0.9m);
        }
        else if (discountCode == "DISCOUNT20OFF")
        {
            return new PercentageDiscountStrategy(0.8m);
        }
        else if (discountCode == "GET5")
        {
            return new FixedDiscountStrategy(5m);
        }
        else
        {
            throw new ArgumentException("Invalid discount code");
        }

    }
}
