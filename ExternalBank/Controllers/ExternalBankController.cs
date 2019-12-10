using ExternalBank.Engine;
using ExternalBankWrapper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ExternalBank.Controllers
{
    public class ExternalBankController : ApiController
    {
        #region constructor
        public ExternalBankController() { }
        #endregion

        [HttpPost]
        public async Task<ResponseModel> ProcessPayment([FromBody]ProcessPaymentModel paymentModel)
        {
            using (ExternalBankEngine externalBankEngine = new ExternalBankEngine())
            {
                return await externalBankEngine.ProcessPayment(paymentModel);
            }
        }

        [HttpGet]
        public async Task<List<AcquiringBankModel>> GetAllPaymentData()
        {
            using (ExternalBankEngine externalBankEngine = new ExternalBankEngine())
            {
                return (await externalBankEngine.GetAllPaymentData()).Select(x => new AcquiringBankModel
                {
                    AcquiringBankId = x.AcquiringBankId,
                    Amount = x.Amount,
                    IsSuccess = x.IsSuccess,
                    LastModifiedTimeStamp = x.LastModifiedTimeStamp
                }).ToList();
            }
        }
    }
}
