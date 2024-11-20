using System;
using System.Collections.Generic;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SensorService sensorService1 = new SensorService();
            // SensorService sensorService  = new SensorService(new FakeSensorRepository() );

            decimal value = sensorService1.GetValue(1);
            Console.WriteLine(value);

            Console.WriteLine("Hello Command Pattern!");

            Message message = new Message("555000123", "555888000", "Hello World!");

            PrintCommand printCommand = new PrintCommand(message, 3);

            string json = System.Text.Json.JsonSerializer.Serialize(printCommand);

            Console.WriteLine(json);

            ICommand sendCommand = new SendCommand(message);

            CompositeCommand command = new CompositeCommand();
            command.RegisterCommand(sendCommand);
            command.RegisterCommand(printCommand);
            command.RegisterCommand(printCommand);
            command.RegisterCommand(printCommand);

            BackgroundService backgroundService = new BackgroundService(command);
            backgroundService.DoWork();





        }
    }

}
