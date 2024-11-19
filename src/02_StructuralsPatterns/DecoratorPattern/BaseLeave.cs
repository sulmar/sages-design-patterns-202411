namespace DecoratorPattern;

// Concrete Component
public class BaseLeave : ILeaveCalculator
{
    private int _baseLeaveDays;

    public BaseLeave(int baseLeaveDays)
    {
        _baseLeaveDays = baseLeaveDays;
    }

    public int CalculateLeaveDays()
    {
        return _baseLeaveDays;
    }
}