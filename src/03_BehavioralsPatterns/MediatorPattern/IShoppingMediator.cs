using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern;

// Abstract Medatior
public interface IShoppingMediator
{
    void ProcessPayment(decimal amount);
}


// Concrete Mediator
public class ShoppingMediator : IShoppingMediator
{
    PaymentProcessor paymentProcessor;
    EmailNotifier emailNotifier;

    public ShoppingMediator(PaymentProcessor paymentProcessor, EmailNotifier emailNotifier)
    {
        this.paymentProcessor = paymentProcessor;
        this.emailNotifier = emailNotifier;
    }

    public void ProcessPayment(decimal amount)
    {
        paymentProcessor.ProcessPayment(amount);

        // Po przetworzeniu płatności wysyłamy potwierdzenie
        emailNotifier.SendConfirmation("user@example.com");
    }

    
}