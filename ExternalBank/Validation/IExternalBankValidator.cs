using ExternalBankWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExternalBank.Validation
{
    public interface IExternalBankValidator
    {
        bool ValidatePaymentModel(ProcessPaymentModel paymentModel);
    }
}