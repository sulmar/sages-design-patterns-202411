using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern.Models;


public class MessageContext
{
    // Request
    public Message Message { get; set; }

    // Response
    public string TaxNumber { get; set; }

    public MessageContext(Message message)
    {
        Message = message;
    }
}

public class Message
{
    public string From { get; set; }
    public string Title { get; set; }   
    public string Body { get;  set; }
}

// Abstract Handler
public interface IMessageHandler
{    
    void Handle(MessageContext context);
    void SetNext(IMessageHandler next);
}

public abstract class MessageHandler : IMessageHandler
{
    protected IMessageHandler next;
    public void SetNext(IMessageHandler next)
    {
        this.next = next;
    }

    public virtual void Handle(MessageContext message)
    {
        if (next != null)
        {
            next.Handle(message);
        }
    }
}

// Concrete Handler A
public class ValidateFromWhitelistHandler : MessageHandler
{
    private string[] whiteList;

    public ValidateFromWhitelistHandler(string[] whiteList)
    {
        this.whiteList = whiteList;
    }

    public override void Handle(MessageContext context)
    {
        ValidateFromWhitelist(context.Message);

        base.Handle(context);
    }

    private void ValidateFromWhitelist(Message message)
    {
        if (!whiteList.Contains(message.From))
        {
            throw new Exception();
        }
    }
}

// Concrete Handler B
public class ValidateTitleContainsOrderHandler : MessageHandler
{
    public override void Handle(MessageContext context)
    {
        ValidateTitleContainsOrder(context.Message);

        base.Handle(context);
    }

    private static void ValidateTitleContainsOrder(Message message)
    {
        if (!message.Title.Contains("Order"))
        {
            throw new Exception();
        }
    }
}

// Concrete Handler C
public class ExtractTaxNumberFromBodyHandler : MessageHandler
{
    public override void Handle(MessageContext context)
    {
        context.TaxNumber = ExtractTaxNumberFromBody(context.Message);

        base.Handle(context);
    }

    private static string ExtractTaxNumberFromBody(Message message)
    {
        string pattern = @"\b(\d{10}|\d{3}-\d{3}-\d{2}-\d{2})\b";
        Regex regex = new Regex(pattern);
        Match match = regex.Match(message.Body);

        if (match.Success)
        {
            string taxNumber = match.Value;

            return taxNumber;
        }
        else
        {
            throw new FormatException();
        }
    }
}

// Abstraction Builder
public interface IMessageHandlerBuilder 
{
    MessageHandlerBuilder Register(IMessageHandler next);
    IMessageHandler Build();
}

// Concrete Builder
public class MessageHandlerBuilder : IMessageHandlerBuilder
{    
    private IMessageHandler rootHandler;
    private IMessageHandler prevHandler;

    public MessageHandlerBuilder Register(IMessageHandler next)
    {
        if (rootHandler == null && prevHandler == null)
        {
            rootHandler = next;
            prevHandler = next;
        }
        else
        {
            prevHandler.SetNext(next);
            prevHandler = next;
        }

        return this;
    }

    public IMessageHandler Build() => rootHandler;
}


public class MessageHandlerComposite : IMessageHandler
{
    private readonly List<IMessageHandler> handlers;

    public MessageHandlerComposite(List<IMessageHandler> handlers)
    {
        this.handlers = handlers;

        //var query = 
        //    handlers.Zip(handlers.Skip(1),
        //    (current, next) => current.SetNext(next));

        // -
        //  -
        //   -
    }

    public void Handle(MessageContext context)
    {
        throw new NotImplementedException();
    }

    public void SetNext(IMessageHandler next)
    {
        throw new NotImplementedException();
    }
}



public class MessageProcessor
{
    IMessageHandler handler;

    public MessageProcessor(IMessageHandler handler)
    {
        this.handler = handler;

    }

    public string Process(Message message)
    {       
        MessageContext context = new MessageContext(message);

        handler.Handle(context);

         return context.TaxNumber;

    }

   

   

  
}
