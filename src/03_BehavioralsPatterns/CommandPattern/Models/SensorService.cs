using System;

namespace CommandPattern;

public class Sensor
{
    public int Id { get; set; }
    public int Value { get; set; }
}

public interface ISensorRepository
{
    Sensor Get(int id);
}

public class FakeSensorRepository : ISensorRepository
{
    public Sensor Get(int id) => new Sensor { Id = 999 };
}

public class DbSensorRepository : ISensorRepository
{
    public Sensor Get(int id)
    {
        Console.WriteLine("db");
        return new Sensor { Id = id };
    }
}

public interface IMeasureSensor
{
    decimal GetMeasure();
}

public class RealMeasureSensor : IMeasureSensor
{
    public decimal GetMeasure()
    {
        return Calculate();
    }

    private decimal Calculate()
    {
        return 100;
    }
}


public class SensorService
{
    private readonly ISensorRepository repository;
    private readonly IMeasureSensor measureSensor;

    public SensorService()
        : this(new DbSensorRepository(), new RealMeasureSensor())
    {
        
    }

    public SensorService(ISensorRepository sensorRepository, IMeasureSensor measureSensor = null)
    {
        repository = sensorRepository;
        this.measureSensor = measureSensor;
    }

    public decimal GetValue(int id)
    {
        Sensor sensor = repository.Get(id);

        return measureSensor.GetMeasure();
    }

   
}
