namespace DecoratorPattern;

// Concrete Decorator B
public class CompletedTrainingLeaveDecorator : LeaveDecorator
{
    private bool _hasCompletedTraining;

    public CompletedTrainingLeaveDecorator(ILeaveCalculator leaveCalculator, bool hasCompletedTraining) : base(leaveCalculator)
    {
        _hasCompletedTraining = hasCompletedTraining;
    }

    public override int CalculateLeaveDays()
    {
        // Dodanie dni za ukończone szkolenia
        int extraLeave = _hasCompletedTraining ? 3 : 0;

        return leaveCalculator.CalculateLeaveDays() + extraLeave;
    }
}



