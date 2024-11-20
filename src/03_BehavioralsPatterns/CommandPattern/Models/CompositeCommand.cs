using System.Collections.Generic;

namespace CommandPattern;

public class CompositeCommand : ICommand
{
    Queue<ICommand> commands = new Queue<ICommand>();

    public void RegisterCommand(ICommand command)
    {
        commands.Enqueue(command);
    }

    public void Execute()
    {
        while (commands.Count > 0)
        {
            ICommand command = commands.Dequeue();

            command.Execute();
        }
    }
}
