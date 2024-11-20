using System;
using System.Reflection.Metadata;

namespace CommandPattern;

// Abstract Command
public interface ICommand
{
    void Execute();

    public bool CanExecute()
    {
        return true;
    }
}

// Concrete Command A
public class SendCommand : ICommand
{
    public Message Message { get; }

    public SendCommand(Message message)
    {
        Message = message;
    }

    public void Execute()
    {
        if (CanExecute())
            Console.WriteLine($"Send message from <{Message.From}> to <{Message.To}> {Message.Content}");
    }

    public bool CanExecute()
    {
        return !(string.IsNullOrEmpty(Message.From) || string.IsNullOrEmpty(Message.To) || string.IsNullOrEmpty(Message.Content));
    }
}

// Concrete Command B
public class PrintCommand : ICommand
{
    public Message Message { get; }

    public int copies { get; }

    public PrintCommand(Message message, int copies)
    {
        this.Message = message;
        this.copies = copies;
    }

    public void Execute()
    {
        if (CanExecute())
        {
            for (int i = 0; i < copies; i++)
            {
                Console.WriteLine($"Print message from <{Message.From}> to <{Message.To}> {Message.Content}");
            }
        }
    }

    public bool CanExecute()
    {
        return string.IsNullOrEmpty(Message.Content);
    }
}


public class Message
{
    public Message(string from, string to, string content)
    {
        From = from;
        To = to;
        Content = content;
    }

    public string From { get; set; }
    public string To { get; set; }
    public string Content { get; set; }

}
