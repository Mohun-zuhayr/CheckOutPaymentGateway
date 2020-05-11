using CheckOutPaymentGateway.Validation;
using CheckOutPaymentGatewayWrapper.Model;
using ExternalBankWrapper.Expo;
using ExternalBankWrapper.Models;
using NLog;
using System;
using Serilog;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using States = CheckOutPaymentGatewayWrapper.Model.States;
using CheckOutPaymentGateway.EncryptionEngine;

namespace CheckOutPaymentGateway.Engine
{
    public class PaymentEngine : IPaymentEngine, IDisposable
    {
        private PaymentGatewayValidator validator = null;
        private const string secretKey = "ssshhhhhhhhhhh!!!!";
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #region constructor
        public PaymentEngine()
        {
            validator = new PaymentGatewayValidator();
        }
        #endregion

        #region Interface Implementation
        public async Task<ResponseAPIModel> ProcessPayment(ProcessPaymentAPIModel paymentModel)
        {
            //Serilog implementation
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5341")
            .CreateLogger();

            logger.Info("Starting Process Payment...");
            Log.Information("Starting Process Payment...");
            logger.Info("Validating process payment model");
            Log.Information("Validating process payment model");

            if (paymentModel != null && validator.ValidatePaymentModel(paymentModel, logger))
            {
                logger.Info("Valid payment model");
                Log.Information("Valid payment model");

                ProcessPaymentModel processModel = BuildPaymentModel(paymentModel);

                //contact and expose data to external bank api
                ExternalBankExpo contactExternalBank = new ExternalBankExpo();
                logger.Info("Contacting external bank endpoints");
                Log.Information("Contacting external bank endpoints");

                try
                {
                    var response = contactExternalBank.ProcessPayment(processModel);

                    if (response != null && response.ResponseStatus == States.Success.ToString())
                    {
                        logger.Info("Success in contacting external bank endpoints");
                        Log.Information("Success in contacting external bank endpoints");


                        //build transaction model and save data to db
                        Transaction transaction = BuildTransactionModel(processModel, response);

                        logger.Info("Attempting to save transaction");
                        Log.Information("Attempting to save transaction");

                        try
                        {
                            using (CheckOutPaymentGatewayEntities db = new CheckOutPaymentGatewayEntities())
                            {
                                db.Transactions.Add(transaction);
                                await db.SaveChangesAsync();
                            }

                            if (transaction.TransactionStatus == States.Success.ToString())
                                logger.Info("Transaction saved successfully");
                            else logger.Error("Transaction failed");

                            return transaction.TransactionStatus == States.Success.ToString() ? new ResponseAPIModel(States.Success)
                                : new ResponseAPIModel(States.Error, "Cannot execute transaction");
                        }
                        catch (Exception ee)
                        {
                            logger.Error("Failed to contact perform transaction - " + ee.ToString());
                            Log.Information("Failed to contact perform transaction - " + ee.ToString());

                        }
                    }
                    else
                    {
                        logger.Error("Failed to contact external bank endpoints");
                        Log.Information("Failed to contact external bank endpoints");

                        return new ResponseAPIModel(States.Error, "Cannot contact and process payment to external bank");
                    }
                }
                catch (Exception e)
                {
                    logger.Error("Failed to contact external bank endpoints - " + e.ToString());
                    Log.Information("Failed to contact external bank endpoints - " + e.ToString());

                    return new ResponseAPIModel(States.Error, "Cannot contact and process payment to external bank");
                }

            }
            logger.Error("Invalid payment model");
            Log.CloseAndFlush();
            return new ResponseAPIModel(States.Error, "Invalid payment api model");
        }

        public async Task<List<TransactionAPIModel>> GetTransactions(Guid merchantId)
        {
            List<Transaction> transactions = new List<Transaction>();
            using (CheckOutPaymentGatewayEntities db = new CheckOutPaymentGatewayEntities())
            {
                transactions = await db.Transactions.Where(x => x.MerchantId == merchantId).ToListAsync();
            }

            return transactions.Select(x => new TransactionAPIModel
            {
                Amount = x.Amount,
                CardExpiryDate = x.CardExpiryDate,
                MaskedCardNumber = PrepareMask(EncryDecryMechanism.DecryptData(x.CardNumber, secretKey)),
                CardCurrency = x.CardCurrency,
                TransactionStatus = x.TransactionStatus,
                TransactionDateTime = x.TransactionDateTime
            }).ToList();
        }

        public void Dispose()
        {
            validator = null;
        }
        #endregion

        #region Private Methods
        private static Transaction BuildTransactionModel(ProcessPaymentModel processModel, ResponseModel response)
        {
            logger.Info("Build transaction models");
            return new Transaction
            {
                TransactionId = response.TransactionID,
                MerchantId = processModel.MerchantId,
                CardNumber = EncryDecryMechanism.EncryptData(processModel.CardNumber, secretKey),
                CardExpiryDate = processModel.ExpiryDate,
                CardCurrency = processModel.Currency,
                Amount = processModel.Amount,
                TransactionDateTime = DateTime.Now,
                TransactionStatus = response.ResponseStatus
            };
        }

        private static ProcessPaymentModel BuildPaymentModel(ProcessPaymentAPIModel paymentModel)
        {
            logger.Info("Building payment process model");
            return new ProcessPaymentModel
            {
                MerchantId = paymentModel.MerchantId,
                Amount = paymentModel.Amount,
                CardNumber = EncryDecryMechanism.EncryptData(paymentModel.CardNumber, secretKey),
                CVV = paymentModel.CVV,
                Currency = paymentModel.Currency,
                ExpiryDate = paymentModel.ExpiryDate
            };
        }

        private static string PrepareMask(string cardNumber)
        {
            List<char> maskedCard = new List<char>();
            int count = 0;
            foreach (char c in cardNumber)
            {
                if (c != ' ' && count > 3)
                {
                    maskedCard.Add('X');
                }
                else
                {
                    maskedCard.Add(c);
                    count++;
                }
            }
            return new string(maskedCard.ToArray());
        }
        #endregion
    }
}