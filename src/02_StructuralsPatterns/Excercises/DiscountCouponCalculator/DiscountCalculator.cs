using System.Net.Http.Headers;

namespace DiscountCouponCalculator;

public class DiscountCalculator
{
    private readonly HashSet<string> discountCoupons = new();

    public DiscountCalculator()
    {
        discountCoupons.Add("ABC");
        discountCoupons.Add("XYZ");
    }

    public decimal CalculateDiscount(decimal price, string discountCode)
    {
        if (price < 0)
            throw new ArgumentOutOfRangeException();

        if (string.IsNullOrEmpty(discountCode))
            return price;

        if (discountCode == "SAVE10NOW")
        {
            return price * 0.9m;
        }
        else if (discountCode == "DISCOUNT20OFF")
        {
            return price * 0.8m;
        }

        else if (discountCoupons.Contains(discountCode))
        {
            discountCoupons.Remove(discountCode);   

            return price * 0.5m;
        }

        else
        {
            throw new ArgumentException("Invalid discount code");
        }


        return price;
    }
}
