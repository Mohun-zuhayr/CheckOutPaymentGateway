using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutPaymentGatewayWrapper.Model
{
    public enum States { Success, Error }
    public class ResponseAPIModel
    {
        public ResponseAPIModel(States responseStatus)
        {
            TransactionID = Guid.NewGuid();
            ResponseStatus = responseStatus.ToString();
        }
        public ResponseAPIModel(States responseStatus, string message)
        {
            TransactionID = Guid.NewGuid();
            ResponseStatus = responseStatus.ToString();
            ResponseMessage = message;
        }
        public ResponseAPIModel()
        {
        }

        public Guid TransactionID { get; set; }
        public string ResponseStatus { get; set; }
        public string ResponseMessage { get; set; }
    }
}
