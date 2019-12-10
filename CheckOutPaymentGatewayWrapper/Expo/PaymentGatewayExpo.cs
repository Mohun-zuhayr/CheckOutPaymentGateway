using CheckOutPaymentGatewayWrapper.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutPaymentGatewayWrapper.Expo
{
   public class PaymentGatewayExpo
    {
        public ResponseAPIModel ProcessPayment(ProcessPaymentAPIModel paymentModel)
        {
            var client = new RestClient("http://localhost:52843/api/PaymentGateway/GetTransactions");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("paymentModel", JsonConvert.SerializeObject(paymentModel), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<ResponseAPIModel>(response.Content);
        }

        public List<TransactionAPIModel> GetTransactions(Guid merchantId)
        {
            var client = new RestClient($"http://localhost:52843/api/PaymentGateway/GetTransactions?merchantId={merchantId}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<TransactionAPIModel>>(response.Content);
        }
    }
}
