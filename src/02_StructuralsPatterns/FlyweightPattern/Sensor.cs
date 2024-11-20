using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern;


public class SensorFactory
{
    private readonly Dictionary<string, Sensor> _sensors = [];

    public Sensor GetSensor(string type, string model, string manufacture)
    {
        string key = $"{type}:{model}:{manufacture}";

        if (!_sensors.ContainsKey(key))
        {
            _sensors[key] = new Sensor(type, model, manufacture);   
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

        Image = new byte[1024];
    }

    public void DisplaySensorData()
    {
        Console.WriteLine($"Typ: {Type}, Model: {Model}, Producent: {Manufacture}");
        // Console.WriteLine($"Wartość: {Value}");
    }
}
