using ExternalBankWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ExternalBank.Engine
{
    public interface IExternalBankEngine
    {
        Task<List<AcquiringBankDBAccount>> GetAllPaymentData();
        Task<ResponseModel> ProcessPayment(ProcessPaymentModel paymentModel);
    }
}