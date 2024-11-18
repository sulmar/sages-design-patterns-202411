namespace LabelPrinterLibrary.UnitTests;


public class PrinterDirectorTests
{
    [Fact]
    public void PrintLabel_ValidLabel_ShouldReturnFormated()
    {
        // Arrange
        PrinterDirector printerDirector = new PrinterDirector(new ZplCommandBuilder(), new LabelPrinterServiceFactory());

        // Act
        printerDirector.PrintLabel(new Product { Name = "abc", Barcode = "123" });

        // Assert        
        
    }
}

public class ZplCommandBuilderTests
{
    ICommandBuilder builder;
    
    public ZplCommandBuilderTests()
    {
        // Arrange
        builder = new ZplCommandBuilder();
    }


    // Method_Scenario_ExpectedBehavior

    [Fact]
    public void AddHeader_WhenCalled_ShouldReturnsHeader()
    {       

        // Act
        builder.AddHeader();
        var result = builder.GetContent();

        // Assert
        Assert.Equal("^XA" + Environment.NewLine, result);

    }

    [Fact]
    public void AddFooter_WhenCalled_ShouldReturnsFooter()
    {

        // Act
        builder.AddFooter();
        var result = builder.GetContent();

        // Assert
        Assert.Equal("^XZ" + Environment.NewLine, result);

    }

    [Fact]
    public void AddText_NotEmpty_ShouldReturnsContent()
    {

        // Act
        builder.AddText("Hello World");
        var result = builder.GetContent();

        // Assert
        Assert.Equal("^FDHello World" + Environment.NewLine, result);

    }

    [Fact]
    public void AddText_Empty_ShouldThrowArgumentNullException()
    {

        // Act
        Action act = () => builder.AddText(string.Empty);
       

        // Assert
        Assert.Throws<ArgumentNullException>(act);
       

    }
}