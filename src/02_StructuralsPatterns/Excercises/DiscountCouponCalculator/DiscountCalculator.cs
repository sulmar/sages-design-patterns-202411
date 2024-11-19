using System.Diagnostics;
using System.Net.Http.Headers;

namespace DiscountCouponCalculator;

public class DiscountCalculator
{
    private readonly IDiscountStrategyFactory factory;

    public DiscountCalculator(IDiscountStrategyFactory factory)
    {
        this.factory = factory;
    }

    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        if (price < 0)
            throw new ArgumentOutOfRangeException();

        // Strategia

        IDiscountStrategy discountStrategy = factory.Create(discountCode);

        return discountStrategy.CalculatePrice(price);

    }
}
