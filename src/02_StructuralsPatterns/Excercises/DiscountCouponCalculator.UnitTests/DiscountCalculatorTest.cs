namespace DiscountCouponCalculator.UnitTests;

public class DiscountCalculatorTest
{

    [Fact]
    public void CalculateDiscount_EmptyCoupon_ShouldReturnOriginalPrice()
    {
        // Arrange
        DiscountCalculator calculator = new DiscountCalculator();

        // Act
        var result = calculator.CalculateDiscount(1, string.Empty);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void CalculateDiscount_SAVE10NOW_ShouldReturnDiscountedPrice()
    {
        // Arrange
        DiscountCalculator calculator = new DiscountCalculator();

        // Act
        var result = calculator.CalculateDiscount(1, "SAVE10NOW");

        // Assert
        Assert.Equal(0.9m, result);
    }

    [Fact]
    public void CalculateDiscount_DISCOUNT20OFF_ShouldReturnDiscountedPrice()
    {
        // Arrange
        DiscountCalculator calculator = new DiscountCalculator();

        // Act
        var result = calculator.CalculateDiscount(1, "DISCOUNT20OFF");

        // Assert
        Assert.Equal(0.8m, result);
    }

    [Fact]
    public void CalculateDiscount_NegativePrice_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange
        DiscountCalculator calculator = new DiscountCalculator();

        // Act
        Action act = () => calculator.CalculateDiscount(-1, string.Empty);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }


    [Fact]
    public void CalculateDiscount_InvalidCoupon_ShouldReturnOriginalPrice()
    {
        // Arrange
        DiscountCalculator calculator = new DiscountCalculator();

        // Act
        Action act = () => calculator.CalculateDiscount(1, "a");

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void CalculateDiscount_OnceCoupon_ShouldReturnDiscountedPrice()
    {
        // Arrange
        DiscountCalculator calculator = new DiscountCalculator();

        // Act
        var result = calculator.CalculateDiscount(1, "ABC");

        // Assert
        Assert.Equal(0.5m, result);
    }

    [Fact]
    public void CalculateDiscount_TwiceCoupon_ShouldReturnDiscountedPrice()
    {
        // Arrange
        DiscountCalculator calculator = new DiscountCalculator();
        calculator.CalculateDiscount(1, "ABC");

        // Act
        Action act = () => calculator.CalculateDiscount(1, "ABC");

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

}