namespace LegacyPrinterExercise;

// Abstract Adapter
public interface IPrinterAdapter
{
    void Print(string document, int copies);
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
    decimal _costPerCopy = 0.1m; // Cost of 0.10 zł per copy

    public void Print(string document, int copies = 1)
    {
        for (int copy = 1; copy <= copies; copy++)
        {
            Console.WriteLine($"Printer is printing: {document}");
        }

        var cost = CalculateCost(copies);
        Console.WriteLine($"{cost:C2}");
    }

    private decimal CalculateCost(int copies)
    {
        // Calculate total cost based on the number of copies and cost per copy
        return copies * _costPerCopy;
    }
}