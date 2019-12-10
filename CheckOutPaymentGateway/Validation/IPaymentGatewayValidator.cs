using CheckOutPaymentGatewayWrapper.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckOutPaymentGateway.Validation
{
    public interface IPaymentGatewayValidator
    {
        bool ValidatePaymentModel(ProcessPaymentAPIModel paymentModel, Logger logger);
    }
}