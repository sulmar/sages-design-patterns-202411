namespace LegacyPrinterExercise.UnitTests;

public class LegacyPrinterTests
{
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