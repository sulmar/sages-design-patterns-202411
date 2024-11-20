using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace LegacyPrinterExercise.UnitTests;

public class LegacyPrinterTests
{

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