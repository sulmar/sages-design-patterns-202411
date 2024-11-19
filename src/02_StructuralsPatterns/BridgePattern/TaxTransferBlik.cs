using System;

namespace BridgePattern;

// Refined Abstraction (Udoskonalona Abstrakcja)
public class TaxTransfer : Transfer
{
    public TaxTransfer(IAuthorizationMethod authorizationMethod) : base(authorizationMethod)
    {
    }

    public override void MakeTransfer(decimal amount)
    {
        authorizationMethod.Authorize();

        Console.WriteLine($"Przelew podatkowy {amount}");

        Console.WriteLine("Wysłanie do US");
    }
}
