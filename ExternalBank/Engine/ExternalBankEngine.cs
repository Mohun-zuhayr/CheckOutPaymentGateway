using ExternalBank.Validation;
using ExternalBankWrapper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ExternalBank.Engine
{
    public class ExternalBankEngine : IExternalBankEngine, IDisposable
    {
        private ExternalBankValidator validator = null;
        #region constructor
        public ExternalBankEngine()
        {
            validator = new ExternalBankValidator();
        }
        #endregion
        
        public async Task<ResponseModel> ProcessPayment(ProcessPaymentModel paymentModel)
        {
            if (paymentModel != null && validator.ValidatePaymentModel(paymentModel))
            {
                var ABAccount = new AcquiringBankDBAccount();
                using (AcquiringBankDBEntities db = new AcquiringBankDBEntities())
                {
                    ABAccount = await db.AcquiringBankDBAccounts.FindAsync(paymentModel.MerchantId);
                }

                if (ABAccount != null)
                {
                    using (AcquiringBankDBEntities db = new AcquiringBankDBEntities())
                    {
                        ABAccount.Amount = paymentModel.Amount;
                        ABAccount.IsSuccess = false;
                        ABAccount.LastModifiedTimeStamp = DateTime.Now;
                        db.Entry(ABAccount).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                    }
                    return new ResponseModel(States.Success);
                }
                else
                {
                    return new ResponseModel(States.Error, "Invalid MerchantId");
                }
            }
            return new ResponseModel(States.Error, "Invalid payment model");
        }
        
        public async Task<List<AcquiringBankDBAccount>> GetAllPaymentData()
        {
            List<AcquiringBankDBAccount> ABAccounts = new List<AcquiringBankDBAccount>();
            using (AcquiringBankDBEntities db = new AcquiringBankDBEntities())
            {
                ABAccounts = await db.AcquiringBankDBAccounts.ToListAsync();
            }
            return ABAccounts;
        }

        public void Dispose()
        {
            validator = null;
        }
    }
}