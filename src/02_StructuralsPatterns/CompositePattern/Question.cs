namespace CompositePattern;


public class QuestionBuilder
{
    private readonly IQuestion question; 

    public QuestionBuilder(string prompt)
    {
        question = new Question(prompt);
    }

    public QuestionBuilder AddPositiveAction(IQuestion positiveAction)
    {
        question..PositiveAction = positiveAction;
    }
}

interface IQuestion
{
    void Ask();
}

// Node
class Question : IQuestion
{
    public string Prompt { get; set; }

    private IQuestion _positiveAction;
    private IQuestion _negativeAction;

  
    public Question(string prompt)
    {
        Prompt = prompt;
    }

    public void AddPositiveAction(IQuestion positiveAction)
    {
        _positiveAction = positiveAction;
    }

    public void AddNegativeAction(IQuestion negativeAction)
    {
        _negativeAction = negativeAction;
    }


    public void Ask()
    {
        Console.Write(Prompt);

        if (Response)
        {
            _positiveAction?.Ask();
        }
        else
        {
            _negativeAction?.Ask();
        }
    }

    public static bool Response => Console.ReadKey().Key == ConsoleKey.Y;
}

// Leaf
class Decision : IQuestion
{
    public string Prompt { get; set; }

    public Decision(string prompt)
    {
        Prompt = prompt;
    }

    public void Ask()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(Prompt);
        Console.ResetColor();
    }
}


