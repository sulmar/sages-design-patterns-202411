using System;
using System.Collections.Generic;
using System.Threading;

namespace FlyweightPattern;

public class SensorFactory
{
    private readonly Dictionary<string, Sensor> _sensors = [];

    public Sensor GetSensor(string type, string model, string manufacture)
    {
        string key = $"{type}:{model}:{manufacture}";

        if (!_sensors.ContainsKey(key))
        {
            var sensor = new Sensor(type, model, manufacture);
            sensor.LoadImage();

            _sensors[key] = sensor;   
        }

        return _sensors[key];
    }
}


public class SensorLocation
{
    public Sensor Sensor { get; set; }
    public string Room { get; set; }
    public byte Floor { get; set; }

    public SensorLocation(Sensor sensor, string room, byte floor)
    {
        Sensor = sensor;
        Room = room;
        Floor = floor;
    }

    public void DisplaySensorData()
    {
        Sensor.DisplaySensorData();
        Console.WriteLine($"Lokalizacja: {Room}, Piętro: {Floor}");
    }
}



public class Sensor
{
    public string Type { get; set; }
    public string Model { get; set; }
    public string Manufacture { get; set; }

    public byte[] Image { get; set; }

    public Sensor(string type, string model, string manufacture)
    {
        Type = type;
        Model = model;
        Manufacture = manufacture;        
    }

    public void LoadImage()
    {
        Thread.Sleep(1000);

        Image = new byte[1024];
    }

    public void DisplaySensorData()
    {
        Console.WriteLine($"Typ: {Type}, Model: {Model}, Producent: {Manufacture}");
        // Console.WriteLine($"Wartość: {Value}");
    }
}
