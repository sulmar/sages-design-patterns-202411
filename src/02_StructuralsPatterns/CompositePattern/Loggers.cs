namespace CompositePattern;

public interface ILogger
{
    void Log(string message);
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
