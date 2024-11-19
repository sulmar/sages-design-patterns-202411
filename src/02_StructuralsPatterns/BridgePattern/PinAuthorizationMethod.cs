using System;

namespace BridgePattern;

public class PinAuthorizationMethod : IAuthorizationMethod
{
    public void Authorize()
    {
        Console.WriteLine("Autoryzacja za pomocą PIN");
    }
}
