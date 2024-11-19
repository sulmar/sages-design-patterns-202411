using System;

namespace BridgePattern;

public class BlikAuthorizationMethod : IAuthorizationMethod
{
    public void Authorize()
    {
        Console.WriteLine("Autoryzacja za pomocą kodu BLIK");
    }
}
