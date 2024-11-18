// Zasada otwarte – zamknięte (Open/Closed Principle) - OCP

// Każda klasa powinna być otwarta na rozbudowę ale zamknięta na modyfikacje.
// Oznacza to, że taka klasa pozwala na rozszerzenie swojego zachowania
// bez modyfikowania kodu źródłowego.

// Przykład łamiący zasadę otwarte – zamknięte
TaxCalculator calculator = new TaxCalculator();

decimal standardTax = calculator.CalculateTax(60000, "Standard");
decimal progressiveTax = calculator.CalculateTax(60000, "Progressive");

Console.WriteLine($"Standard Tax: {standardTax}");
Console.WriteLine($"Progressive Tax: {progressiveTax}");

public class TaxCalculator
{
    public decimal CalculateTax(decimal income, string type)
    {
        decimal tax = 0;

        if (type == "Standard")
        {
            tax = income * 0.2m; // Standard tax rate of 20%
        }
        else if (type == "Progressive")
        {
            if (income <= 50000)
            {
                tax = income * 0.1m; // 10% tax for income up to 50000
            }
            else
            {
                tax = income * 0.3m; // 30% tax for income above 50000
            }
        }

        return tax;
    }
}