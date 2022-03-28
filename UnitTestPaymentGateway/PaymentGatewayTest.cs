using ExternalBankWrapper.Expo;
using ExternalBankWrapper.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestPaymentGateway
{
    [TestClass]
    public class PaymentGatewayTest
    {
        [TestMethod]
        public void ProcessPayment()
        {
            ExternalBankExpo contactExternalBank = new ExternalBankExpo();
            ProcessPaymentModel processModel = new ProcessPaymentModel 
                {
                    MerchantId = new Guid(),
                    CardNumber = "123456789007",
                    ExpiryDate = new DateTime(2023, 8, 18),
                    Amount = 1500m,
                    Currency = "USD",
                    CVV = "007"
            };

            ResponseModel response = contactExternalBank.ProcessPayment(processModel);
            Assert.Equals(response, States.Success.ToString());
        }

        [TestMethod]
        public void ProcessInvalidPayment()
        {
            ExternalBankExpo contactExternalBank = new ExternalBankExpo();
            ProcessPaymentModel processModel = new ProcessPaymentModel
            {
                MerchantId = new Guid(),
                CardNumber = "123456789007",
                ExpiryDate = new DateTime(),
                Amount = 1500m,
                Currency = "USD",
                CVV = "aeb007"
            };

            ResponseModel response = contactExternalBank.ProcessPayment(processModel);
            Assert.Equals(response, States.Error.ToString());
        }
    }
}
