namespace DiscountCouponCalculator;

public interface IDiscountStrategyFactory
{
    IDiscountStrategy Create(string discountCode);
}
