namespace DiscountCouponCalculator.UnitTests;

public class DiscountCalculatorTest
{
    DiscountCalculator calculator;
    DiscountStrategyFactoryProxy factory;

    public DiscountCalculatorTest()
    {
        factory = new DiscountStrategyFactoryProxy(new DiscountStrategyFactory());
        calculator = new DiscountCalculator(factory);
    }

    [Fact]
    public void CalculateDiscount_EmptyCoupon_ShouldReturnOriginalPrice()
    {
        // Arrange        

        // Act
        var result = calculator.CalculateDiscount(1, string.Empty);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void CalculateDiscount_SAVE10NOW_ShouldReturnDiscountedPrice()
    {
        // Arrange

        // Act
        var result = calculator.CalculateDiscount(1, "SAVE10NOW");

        // Assert
        Assert.Equal(0.9m, result);
    }

    [Fact]
    public void CalculateDiscount_DISCOUNT20OFF_ShouldReturnDiscountedPrice()
    {
        // Arrange

        // Act
        var result = calculator.CalculateDiscount(1, "DISCOUNT20OFF");

        // Assert
        Assert.Equal(0.8m, result);
    }

    [Fact]
    public void CalculateDiscount_NegativePrice_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange

        // Act
        Action act = () => calculator.CalculateDiscount(-1, string.Empty);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }


    [Fact]
    public void CalculateDiscount_InvalidCoupon_ShouldReturnOriginalPrice()
    {
        // Arrange
        factory.AddDiscountCoupon("ABC");

        // Act
        Action act = () => calculator.CalculateDiscount(1, "a");

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void CalculateDiscount_OnceCoupon_ShouldReturnDiscountedPrice()
    {
        // Arrange
        factory.AddDiscountCoupon("ABC");

        // Act
        var result = calculator.CalculateDiscount(1, "ABC");

        // Assert
        Assert.Equal(0.5m, result);
    }

    [Fact]
    public void CalculateDiscount_TwiceCoupon_ShouldReturnDiscountedPrice()
    {
        // Arrange
        factory.AddDiscountCoupon("ABC");
        calculator.CalculateDiscount(1, "ABC");

        // Act
        Action act = () => calculator.CalculateDiscount(1, "ABC");

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void CalculateDiscount_GET5_ShouldReturnDiscountedPrice()
    {
        // Arrange

        // Act
        var result = calculator.CalculateDiscount(10, "GET5");

        // Assert
        Assert.Equal(5m, result);
    }

}