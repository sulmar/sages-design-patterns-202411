namespace DecoratorPattern;

// Concrete Decorator C
public class SpecialBenefitsLeaveDecorator : LeaveDecorator
{
    public bool _hasSpecialBenefits;

    public SpecialBenefitsLeaveDecorator(ILeaveCalculator leaveCalculator, bool hasSpecialBenefits) : base(leaveCalculator)
    {
        _hasSpecialBenefits = hasSpecialBenefits;
    }

    public override int CalculateLeaveDays()
    {
        // Dodanie dni za specjalne świadczenia
        int extraLeave = _hasSpecialBenefits ? 2 : 0;

        return leaveCalculator.CalculateLeaveDays() + extraLeave;
    }
}