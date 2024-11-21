using ChainOfResponsibilityPattern.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChainOfResponsibilityPattern.UnitTests.UnitTests
{
    [TestClass]
    public class ValidateFromWhitelistHandlerTests
    {

        [TestMethod]
        public void Handle_ValidFrom_ShoudCalledNext()
        {
            // Arrange
            string[] whiteList = ["john@domain.com", "bob@domain.com"];

            IMessageHandler messageHandler = new ValidateFromWhitelistHandler(whiteList);

            Message message = new Message { From = "john@domain.com" };

            MessageContext context = new MessageContext(message);

            // Act
            messageHandler.Handle(context);

            // Assert
            // TODO:  Sprawdz czy metoda base.Handle została wywołana
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Handle_InvalidFrom_ShoudThrowException()
        {
            // Arrange
            string[] whiteList = ["john@domain.com", "bob@domain.com"];

            IMessageHandler messageHandler = new ValidateFromWhitelistHandler(whiteList);

            Message message = new Message { From = "a@domain.com" };

            MessageContext context = new MessageContext(message);

            // Act
            messageHandler.Handle(context);
           
        }
    }
}
