using ExternalBankWrapper.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalBankWrapper.Expo
{
    public class ExternalBankExpo
    {
        public ResponseModel ProcessPayment(ProcessPaymentModel paymentModel)
        {
            var client = new RestClient("http://localhost:52924/api/ExternalBank/ProcessPayment");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("paymentModel", JsonConvert.SerializeObject(paymentModel), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<ResponseModel>(response.Content);
        }

        public List<AcquiringBankModel> GetAllPaymentData()
        {
            var client = new RestClient("http://localhost:52924/api/ExternalBank/GetAllPayment");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<AcquiringBankModel>>(response.Content);
        }
    }
}
