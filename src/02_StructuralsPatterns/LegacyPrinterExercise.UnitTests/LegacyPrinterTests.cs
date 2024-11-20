using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace LegacyPrinterExercise.UnitTests;

public class PrinterTests
{
    [Fact]
    public void PrintDocument_PerCopy_ShouldReturnCost()
    {
        // Arrange
        var printer = new CostPrinterDecorator(new Printer(), new PerCopyCostStrategy(0.1m));

        // Act
        printer.Print("a", 3);

        // Assert
        Assert.Equal(0.3m, printer.Cost);
    }

    [Fact]
    public void PrintDocument_Length_ShouldReturnCost()
    {
        // Arrange
        var printer = new CostPrinterDecorator(new Printer(), new LengthCostStrategy(0.1m));

        // Act
        printer.Print("abc", 3);

        // Assert
        Assert.Equal(0.9m, printer.Cost);
    }
}

public class LegacyPrinterTests
{

    [Fact]
    public void PrintDocument_Multi_ShouldReturnCost()
    {
        // Arrange
        PrinterAdapterFactory factory = new PrinterAdapterFactory();

        IPrinterAdapter printerAdapter = factory.Create("legacy");

        var printer = new CostPrinterDecorator(printerAdapter, new PerCopyCostStrategy(0.2m));

        // Act
        printer.Print("a", 3);
        
        // Assert
        Assert.Equal(0.6m, printer.Cost);
    }

    [Fact]
    public void PrintDocument_Multi_ShouldCalledMulti()
    {
        // Arrange
        IPrinterAdapter printer = new LegacyPrinterAdapter();

        // Przekierowanie konsoli w celu przetestowania
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        printer.Print("a", 3);

        // Assert
        var output = stringWriter.ToString();
        var lineCount = output.Split(Environment.NewLine, StringSplitOptions.None).Length - 1;
        Assert.Equal(3, lineCount);


    }

    [Fact]
    public void PrintDocument()
    {
        // Arrange
        LegacyPrinter printer = new LegacyPrinter();

        // Przekierowanie konsoli w celu przetestowania
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        printer.PrintDocument("a");
        printer.PrintDocument("a");
        printer.PrintDocument("a");

        var output = stringWriter.ToString();

        // Assert

        var lineCount = output.Split(Environment.NewLine, StringSplitOptions.None).Length - 1;

        Assert.Equal(3, lineCount);
    }
}