using System;
using System.IO;
using System.Threading;

namespace DecoratorPattern;


public interface ILeaveCalculator
{
    int CalculateLeaveDays();
}

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

// Abstract Decorator
public abstract class LeaveDecorator : ILeaveCalculator
{
    protected ILeaveCalculator leaveCalculator;

    protected LeaveDecorator(ILeaveCalculator leaveCalculator)
    {
        this.leaveCalculator = leaveCalculator;
    }

    public abstract int CalculateLeaveDays();
}

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



