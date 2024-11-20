using System;

namespace FlyweightPattern;

public class Sensor
{
    public string Type { get; set; }
    public string Model { get; set; }
    public string Manufacture { get; set; }
    public string Room { get; set; }
    public byte Floor { get; set; }
    public double Value { get; set; }

    public Sensor(string type, string model, string manufacture, string room, byte floor, double value)
    {
        Type = type;
        Model = model;
        Manufacture = manufacture;
        Room = room;
        Floor = floor;
        Value = value;
    }

    public void DisplaySensorData()
    {
        Console.WriteLine($"Typ: {Type}, Model: {Model}, Producent: {Manufacture}");
        Console.WriteLine($"Lokalizacja: {Room}, Piętro: {Floor}");
        Console.WriteLine($"Wartość: {Value}");
    }
}
