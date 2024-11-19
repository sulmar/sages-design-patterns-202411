namespace DiscountCouponCalculator;

public interface IDiscountStrategy
{
    decimal CalculatePrice(decimal price);
}
