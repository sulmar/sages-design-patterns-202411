namespace DecoratorPattern;

// Abstract Decorator
public abstract class LeaveDecorator : ILeaveCalculator
{
    // decorated
    protected ILeaveCalculator leaveCalculator;

    protected LeaveDecorator(ILeaveCalculator leaveCalculator)
    {
        this.leaveCalculator = leaveCalculator;
    }

    public abstract int CalculateLeaveDays();
}

