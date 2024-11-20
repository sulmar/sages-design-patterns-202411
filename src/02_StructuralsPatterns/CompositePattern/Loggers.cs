namespace CompositePattern;

public interface ILogger
{
    void Log(string message);
}

public class SqlLogger : ILogger
{
    public SqlLogger(string connectionstring)
    {
    }

    public void Log(string message)
    {
        Console.WriteLine($"SQL: {message}");
    }
}

public class WindowsEventLogLogger : ILogger
{
    private readonly string source;

    public WindowsEventLogLogger(string source)
    {
        this.source = source;
    }

    public void Log(string message)
    {
        Console.WriteLine($"[{source}] {message}");
    }
}

public class FileLogger : ILogger
{
    private readonly string directory;

    public FileLogger(string directory)
    {
        this.directory = directory;
    }

    public void Log(string message)
    {
        Console.WriteLine($"{directory} {message}");
    }
}


public class Loggers
{
    private readonly IEnumerable<ILogger> loggers;

    public Loggers(IEnumerable<ILogger> loggers)
    {
        this.loggers = loggers;
    }

    public void DoSomething()
    {
        foreach (var logger in loggers)
        {
            logger.Log("DoSomething called");
        }

    }
}
