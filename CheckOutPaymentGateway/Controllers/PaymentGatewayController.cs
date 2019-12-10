using CheckOutPaymentGateway.Engine;
using CheckOutPaymentGatewayWrapper.Model;
using ExternalBankWrapper.Expo;
using ExternalBankWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CheckOutPaymentGateway.Controllers
{
    public class PaymentGatewayController : ApiController
    {

        [HttpPost]
        public async Task<ResponseAPIModel> ProcessPayment([FromBody]ProcessPaymentAPIModel processPaymentModel)
        {
            using (PaymentEngine paymentEngine = new PaymentEngine())
            {
                return await paymentEngine.ProcessPayment(processPaymentModel);
            }
        }
      
        public async Task<List<TransactionAPIModel>> GetTransactions(Guid merchantId)
        {
            using (PaymentEngine paymentEngine = new PaymentEngine())
            {
                return await paymentEngine.GetTransactions(merchantId);
            }
        }
    }
}
