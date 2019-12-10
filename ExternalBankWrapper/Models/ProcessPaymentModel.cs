using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalBankWrapper.Models
{
    public class ProcessPaymentModel
    {
        public Guid ProcessPaymentId { get; set; }
        public Guid MerchantId { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string CVV { get; set; }
    }
}
