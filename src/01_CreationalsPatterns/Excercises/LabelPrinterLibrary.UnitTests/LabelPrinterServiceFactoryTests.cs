namespace LabelPrinterLibrary.UnitTests;

public class LabelPrinterServiceFactoryTests
{
    LabelPrinterServiceFactory factory;

    public LabelPrinterServiceFactoryTests()
    {
        // Arrange
        factory = new LabelPrinterServiceFactory();
    }

    [Fact]
    public void Create_WhenConsole_ShouldReturnConsoleLabelPrinterService()
    {
        // Act
        ILabelPrinterService printerService = factory.Create("console");

        // Assert
        Assert.IsType<ConsoleLabelPrinterService>(printerService);

    }

    [Fact]
    public void Create_WhenConsole_ShouldReturnTcpLabelPrinterService()
    {

        // Act
        ILabelPrinterService printerService = factory.Create("tcp");

        // Assert
        Assert.IsType<TcpLabelPrinterService>(printerService);

    }
}
