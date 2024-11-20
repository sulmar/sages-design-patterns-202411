using System;
using System.Collections.Generic;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Command Pattern!");

            Message message = new Message("555000123", "555888000", "Hello World!");

            PrintCommand printCommand = new PrintCommand(message, 3);

            string json = System.Text.Json.JsonSerializer.Serialize(printCommand);

            Console.WriteLine(json);

            ICommand sendCommand = new SendCommand(message);

            Queue<ICommand> commands = new Queue<ICommand>();

            commands.Enqueue(printCommand);
            commands.Enqueue(printCommand);
            commands.Enqueue(printCommand);

            commands.Enqueue(sendCommand);

            while (commands.Count > 0)
            {
                ICommand command = commands.Dequeue();

                command.Execute();
            }


        }
    }

}
