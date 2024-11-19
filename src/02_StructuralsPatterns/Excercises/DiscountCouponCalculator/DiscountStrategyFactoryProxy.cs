namespace DiscountCouponCalculator;

// Wzorzec Proxy
public class DiscountStrategyFactoryProxy : IDiscountStrategyFactory
{
    private readonly HashSet<string> discountCoupons = new();

    public void AddDiscountCoupon(string discountCoupon)
    {
        discountCoupons.Add(discountCoupon);
    }

    // Real Subject
    private readonly IDiscountStrategyFactory discountStrategyFactory;

    public DiscountStrategyFactoryProxy(IDiscountStrategyFactory discountStrategyFactory)
    {
        this.discountStrategyFactory = discountStrategyFactory;
    }

    public IDiscountStrategy Create(string discountCode)
    {
        if (discountCoupons.Contains(discountCode))
        {
            discountCoupons.Remove(discountCode);

            return new PercentageDiscountStrategy(0.5m);
        }
        else
        {
            return discountStrategyFactory.Create(discountCode);
        }

    }
}
