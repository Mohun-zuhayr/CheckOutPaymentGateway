using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalBankWrapper.Models
{
    public class AcquiringBankModel
    {
        public Guid AcquiringBankId { get; set; }
        public decimal Amount { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime LastModifiedTimeStamp { get; set; }
    }
}
