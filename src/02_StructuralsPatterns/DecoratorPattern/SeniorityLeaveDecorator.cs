namespace DecoratorPattern;

// Concrete Decorator A
public class SeniorityLeaveDecorator : LeaveDecorator
{
    public int _seniorityYears;

    public SeniorityLeaveDecorator(ILeaveCalculator leaveCalculator, int seniorityYears) : base(leaveCalculator)
    {
        _seniorityYears = seniorityYears;   
    }

    public override int CalculateLeaveDays()
    {
        // Dodanie dni za staż pracy
        int extraLeave = _seniorityYears >= 5 ? 5 : 0;

        return leaveCalculator.CalculateLeaveDays() + extraLeave;
    }
}



