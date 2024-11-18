using System.Net.Sockets;
using System.Net;
using System.Text;
using static LabelPrinterLibrary.LabelPrinterServiceFactory;

namespace LabelPrinterLibrary;

public class Product
{
    public string Name { get; set; }
    public string Barcode { get; set; }
}

public class PrinterDirector
{
    private ICommandBuilder builder;
    private readonly ILabelPrinterService printerService;

    public PrinterDirector(ICommandBuilder builder, ILabelPrinterService printerService)
    {
        this.builder = builder;
        this.printerService = printerService;
    }

    public void PrintLabel(Product product)
    {
        builder.AddHeader();
        builder.SetLocation(10, 10);
        builder.AddText(product.Name);

        builder.SetLocation(10, 20);
        builder.AddBarcode(product.Barcode);

        builder.AddFooter();

        string content = builder.GetContent();

        printerService.Print(content);
    }
}

public interface ICommandBuilder
{
    void AddHeader();
    void AddText(string text);
    void SetLocation(int x, int y);
    void AddBarcode(string barcode);
    void AddFooter();
    string GetContent();
}

public class EplCommandBulder : ICommandBuilder
{
    public void AddBarcode(string barcode)
    {
        throw new NotImplementedException();
    }

    public void AddFooter()
    {
        throw new NotImplementedException();
    }

    public void AddHeader()
    {
        throw new NotImplementedException();
    }

    public void AddText(string text)
    {
        throw new NotImplementedException();
    }

    public string GetContent()
    {
        throw new NotImplementedException();
    }

    public void SetLocation(int x, int y)
    {
        throw new NotImplementedException();
    }
}

public class ZplCommandBuilder : ICommandBuilder
{
    private StringBuilder builder = new StringBuilder();

    public void AddHeader()
    {
        builder.AppendLine("^XA");
    }

    public void AddText(string text)
    {
        if (string.IsNullOrEmpty(text))
            throw new ArgumentNullException();

        builder.AppendLine($"^FD{text}");
    }

    public void SetLocation(int x, int y)
    {
        builder.AppendLine($"^FO{x},{y}");
    }

    public void AddFooter()
    {
        builder.AppendLine("^XZ");
    }

    public string GetContent()
    {
        return builder.ToString();
    }

    public void AddBarcode(string barcode)
    {
        builder.AppendLine("^B3N,N,100,Y,N");
        builder.AppendLine($"^FD{barcode}^FS");
    }
}


public class LabelPrinterServiceFactory
{
    public ILabelPrinterService Create(string type)
    {
        switch (type)
        {
            case "tcp": return new TcpLabelPrinterService(new TcpLabelPrinterOptions(IPAddress.Parse("localhost"), 10));

            case "console": return new ConsoleLabelPrinterService();

            default:
                throw new NotSupportedException();

        }
    }
}

public interface ILabelPrinterService
{
    public void Print(string content);
}

public class TcpLabelPrinterOptions
{
    public IPAddress IpAdress { get; }
    public int Port { get; }

    public TcpLabelPrinterOptions(IPAddress ipAdress, int port)
    {
        IpAdress = ipAdress;
        Port = port;
    }
}

public class TcpLabelPrinterService : ILabelPrinterService
{
    private TcpLabelPrinterOptions options;

    public TcpLabelPrinterService(TcpLabelPrinterOptions options)
    {
        this.options = options;
    }

    public void Print(string content)
    {
        TcpClient tcpClient = new TcpClient();
        tcpClient.Connect(options.IpAdress, options.Port);

        var stream = new StreamWriter(tcpClient.GetStream());
        stream.Write(content);
        stream.Flush();
        stream.Close();
        tcpClient.Close();
    }

}

public class ConsoleLabelPrinterService : ILabelPrinterService
{
    public void Print(string content)
    {
        Console.WriteLine(content);
    }
}

