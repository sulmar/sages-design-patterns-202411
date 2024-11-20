namespace LegacyPrinterExercise;


public class PrinterAdapterFactory
{
    public IPrinterAdapter Create(string model)
    {
        switch(model)
        {
            case "legacy": return new LegacyPrinterAdapter();
            case "new": return new Printer();

            default:
                throw new NotSupportedException();
        }
    }
}

// Abstract Adapter
public interface IPrinterAdapter
{
    void Print(string document, int copies);
}

public interface ICalculateCost
{
    decimal Cost { get; }
}

public class CostPrinterDecorator : IPrinterAdapter, ICalculateCost
{
    private readonly IPrinterAdapter printer;
    private readonly ICostStrategy costStrategy;

    public decimal Cost { get; private set; }

    public CostPrinterDecorator(IPrinterAdapter printer, ICostStrategy costStrategy)
    {
        this.printer = printer;
        this.costStrategy = costStrategy;
    }

    public void Print(string document, int copies)
    {
        printer.Print(document, copies);

        Cost = costStrategy.CalculateCost(document, copies);

        Console.WriteLine($"{Cost:C2}");
        
    }
}

public interface ICostStrategy
{
    decimal CalculateCost(string document, int copies);
}

// C# 12 Primary Constructor
public class PerCopyCostStrategy(decimal costPerCopy = 0.1m) : ICostStrategy
{
    public decimal CalculateCost(string document, int copies) => copies * costPerCopy;
}

public class LengthCostStrategy(decimal costPerChar = 0.1m) : ICostStrategy
{
    public decimal CalculateCost(string document, int copies)
    {
        return document.Length * copies * costPerChar;
    }
}

// Concrete Adapter (wariant obiektowy)
public class LegacyPrinterAdapter : IPrinterAdapter
{
    private LegacyPrinter printer;

    public LegacyPrinterAdapter()
    {
        printer = new LegacyPrinter();    
    }

    public void Print(string document, int copies)
    {
        for (int copy = 1; copy <= copies; copy++)
        {
            printer.PrintDocument(document);
        }
    }
}

public class LegacyPrinter
{    
    public void PrintDocument(string document)
    {
        Console.WriteLine($"Legacy Printer is printing: {document}");
    }
}

public class Printer : IPrinterAdapter
{
    public void Print(string document, int copies = 1)
    {
        for (int copy = 1; copy <= copies; copy++)
        {
            Console.WriteLine($"Printer is printing: {document}");
        }
    }
}