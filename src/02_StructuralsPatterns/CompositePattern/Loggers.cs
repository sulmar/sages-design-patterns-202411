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

public class Component
{
    private ILogger logger;

    public Component(ILogger logger)
    {
        this.logger = logger;
    }

    public void DoSomething()
    {
        logger.Log("DoSomething called");
    }
}

public class CompositeLogger : ILogger
{
    private readonly List<ILogger> loggers = [];
    

    public void AddLogger(ILogger logger)
    {
        loggers.Add(logger);
    }

    public void Log(string message)
    {
        foreach (var logger in loggers)
        {
            logger.Log(message);
        }
    }
}
