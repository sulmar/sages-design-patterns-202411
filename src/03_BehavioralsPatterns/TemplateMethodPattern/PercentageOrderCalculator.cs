namespace TemplateMethodPattern;

// Template Method
public abstract class PercentageOrderCalculator
{    
    protected readonly decimal percentage;

    public abstract bool CanDiscount(Order order);

    public PercentageOrderCalculator(decimal percentage)
    {
        this.percentage = percentage;
    }

    public decimal CalculateDiscount(Order order) // Template Method
    {
        if (CanDiscount(order))
        {
            return order.Amount * percentage;
        }
        else
            return 0;
    }
}
