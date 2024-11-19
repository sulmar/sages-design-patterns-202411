using Xunit;

namespace DecoratorPattern.UnitTests;

public class EmployeeLeaveTests
{
    [Fact]
    public void CalculateLeaveDays_WhenNoAdditionalConditions_ShouldReturnBaseLeave()
    {
        // Arrange
        ILeaveCalculator employeeLeave = new BaseLeave(baseLeaveDays: 20);

        // Act
        int result = employeeLeave.CalculateLeaveDays();

        // Assert
        Assert.Equal(20, result);
    }

    [Fact]
    public void CalculateLeaveDays_ForSeniorityOf5OrMoreYears_ShouldAdd5Days()
    {
        // Arrange
        ILeaveCalculator employeeLeave = new SeniorityLeaveDecorator(
                                        new BaseLeave(baseLeaveDays: 20), seniorityYears: 5);

        // Act
        int result = employeeLeave.CalculateLeaveDays();

        // Assert
        Assert.Equal(25, result);
    }

    [Fact]
    public void CalculateLeaveDays_ForCompletedTraining_ShouldAdd3Days()
    {
        // Arrange
        ILeaveCalculator employeeLeave = new CompletedTrainingLeaveDecorator(new BaseLeave(baseLeaveDays: 20), hasCompletedTraining: true);

        // Act
        int result = employeeLeave.CalculateLeaveDays();

        // Assert
        Assert.Equal(23, result);
    }

    [Fact]
    public void CalculateLeaveDays_ForSpecialBenefits_ShouldAdd2Days()
    {
        // Arrange
        ILeaveCalculator employeeLeave = new SpecialBenefitsLeaveDecorator( new BaseLeave(baseLeaveDays: 20), hasSpecialBenefits: true);

        // Act
        int result = employeeLeave.CalculateLeaveDays();

        // Assert
        Assert.Equal(22, result);
    }

    [Fact]
    public void CalculateLeaveDays_ForAllConditionsMet_ShouldReturn30()
    {
        // Arrange
        ILeaveCalculator employeeLeave = new SpecialBenefitsLeaveDecorator( 
                                        new CompletedTrainingLeaveDecorator( 
                                            new SeniorityLeaveDecorator( 
                                                new BaseLeave(baseLeaveDays: 20), seniorityYears: 5), hasCompletedTraining: true), hasSpecialBenefits: true);

        // Act
        int result = employeeLeave.CalculateLeaveDays();

        // Assert
        Assert.Equal(30, result);
    }

    [Theory]
    [InlineData(20, 4, false, false, 20)] // Bez dodatkowych warunków
    [InlineData(20, 5, false, false, 25)] // Dodatkowe dni za staż
    [InlineData(20, 5, true, false, 28)] // Staż + szkolenie
    [InlineData(20, 5, true, true, 30)] // Wszystkie warunki spełnione
    [InlineData(20, 2, true, true, 25)] // Szkolenie + świadczenia, brak stażu
    public void CalculateLeaveDays_ShouldReturnExpectedDays(int baseDays, int seniority, bool training, bool benefits, int expected)
    {
        // Arrange
        ILeaveCalculator employeeLeave = new SpecialBenefitsLeaveDecorator(
                                      new CompletedTrainingLeaveDecorator(
                                          new SeniorityLeaveDecorator(
                                              new BaseLeave(baseLeaveDays: baseDays), seniorityYears: seniority), hasCompletedTraining: training), hasSpecialBenefits: benefits);


        // Act
        int result = employeeLeave.CalculateLeaveDays();

        // Assert
        Assert.Equal(expected, result);
    }


}
