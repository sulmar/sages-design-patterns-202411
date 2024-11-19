using System;

namespace BridgePattern;

// Abstraction
public abstract class Transfer
{
    protected IAuthorizationMethod authorizationMethod;

    protected Transfer(IAuthorizationMethod authorizationMethod)
    {
        this.authorizationMethod = authorizationMethod;
    }

    public abstract void MakeTransfer(decimal amount);
}

// Abstraction
public abstract class Request
{
    protected IProtocol protocol;

    protected Request(IProtocol protocol)
    {
        this.protocol = protocol;
    }

    public abstract void Start(int devideId);
    public abstract void Stop(int deviceId);

}

// Refined Abstraction A
public class TcpRequest : Request
{
    public TcpRequest(IProtocol protocol) : base(protocol)
    {
    }

    public override void Start(int devideId)
    {
        Console.WriteLine("Connecting by tcp...");

        protocol.Start(devideId);

        Console.WriteLine("Disconnecting...");
    }


    public override void Stop(int deviceId)
    {
        throw new NotImplementedException();
    }
}


// Refined Abstraction B
public class HttpRequest : Request
{
    public HttpRequest(IProtocol protocol) : base(protocol)
    {
    }

    public override void Start(int devideId)
    {
        Console.WriteLine("Connecting by httpclient...");

        protocol.Start(devideId);

        Console.WriteLine("Close httpclient...");
    }

    public override void Stop(int deviceId)
    {
        throw new NotImplementedException();
    }
}


// Abstract Implementor
public interface IProtocol
{
    void Start(int deviceId);
    void Stop(int deviceId);
}

// Concrete Implementor A
public class ModbusProtocol : IProtocol
{
    public void Start(int devideId)
    {
        Console.WriteLine("Ustaw rejestr A");
        Console.WriteLine("Ustaw rejestr B");
        Console.WriteLine("Ustaw rejestr C");
    }

    public void Stop(int deviceId)
    {
        throw new System.NotImplementedException();
    }
}






