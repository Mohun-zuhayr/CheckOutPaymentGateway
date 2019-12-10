using CheckOutPaymentGatewayWrapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CheckOutPaymentGateway.Engine
{
    public interface IPaymentEngine
    {
        Task<ResponseAPIModel> ProcessPayment(ProcessPaymentAPIModel paymentModel);
        Task<List<TransactionAPIModel>> GetTransactions(Guid merchantId);
    }
}