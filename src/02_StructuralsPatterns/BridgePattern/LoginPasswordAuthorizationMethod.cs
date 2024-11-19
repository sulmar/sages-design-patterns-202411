using System;

namespace BridgePattern;

public class LoginPasswordAuthorizationMethod : IAuthorizationMethod
{
    public void Authorize()
    {
        Console.WriteLine("Autoryzacja za pomocą loginu i hasła.");
    }
}
