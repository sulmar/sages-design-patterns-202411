using System.ComponentModel;

namespace CompositePattern;

class Program
{
    static void Main(string[] args)
    {
        LoggerTest();

        // FormTest();



    }

    private static void LoggerTest()
    {
        IEnumerable<ILogger> loggers = new ILogger[]
        {
         new SqlLogger("server=abc"),
         new WindowsEventLogLogger(source: "My app"),
         new FileLogger(directory: "c:\\logs")
        };

        var component = new Component(loggers);

        component.DoSomething();
    }

    private static void FormTest()
    {
        Console.Write("Are you developer?");

        if (Response)
        {

            Console.Write("Do you know C#?");

            if (Response)
            {
                Console.WriteLine("Welcome on Design Pattern in C# Course!");
            }
            else
            {
                Console.WriteLine("The Course is not for you.");
            }

        }
        else
        {
            Console.WriteLine("Have a nice day.");
        }
    }

    public static bool Response => Console.ReadKey().Key == ConsoleKey.Y;

}
