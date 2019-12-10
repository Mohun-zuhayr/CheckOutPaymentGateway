using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutPaymentGatewayWrapper.Model
{
    public class TransactionAPIModel
    {
        public Guid TransactionId { get; set; }
        public Guid MerchantId { get; set; }
        public string CardNumber { get; set; }
        public string MaskedCardNumber { get; set; }
        public DateTime CardExpiryDate { get; set; }
        public string CardCurrency { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string TransactionStatus { get; set; }
    }
}
