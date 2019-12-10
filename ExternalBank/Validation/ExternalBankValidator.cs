using ExternalBankWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExternalBank.Validation
{
    public class ExternalBankValidator : IExternalBankValidator
    {
        public ExternalBankValidator() { }
        public bool ValidatePaymentModel(ProcessPaymentModel paymentModel)
        {
            //Simple model validation 
            //TO-DO: Add more robust one 
            return paymentModel.MerchantId != null ? true : false;
        }
    }
}