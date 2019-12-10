using CheckOutPaymentGatewayWrapper.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckOutPaymentGateway.Validation
{
    public class PaymentGatewayValidator : IPaymentGatewayValidator
    {
        public PaymentGatewayValidator() { }
        public bool ValidatePaymentModel(ProcessPaymentAPIModel paymentModel, Logger logger)
        {
            //Simple model validation 
            //TO-DO: Add more robust one 
            
            if (paymentModel.MerchantId == null)
            {
                logger.Error("Merchant Id is null");
                return false;
            }
            
            if (paymentModel.CardNumber == null)
            {
                logger.Error("Card number is null");
                return false;
            }
            if (!IsValidCardNumber(paymentModel.CardNumber))
            {
                logger.Error("Card number is invalid");
                return false;
            }
            
            if (paymentModel.ExpiryDate < DateTime.Now)
            {
                logger.Error("Expiry date cannot be less than today's date");
                return false;
            }

            if (!isValidExpiryDate(paymentModel.ExpiryDate.ToString()))
            {
                logger.Error("Expiry date is invalid");
                return false;
            }

            if (paymentModel.ExpiryDate == null)
            {
                logger.Error("Expiry date is null");
                return false;
            }
            
            if (paymentModel.Amount < 1)
            {
                logger.Error("Amount cannot be negative");
                return false;
            }
            
            if (!ContainsNumbers(paymentModel.CVV))
            {
                logger.Error("CVV cannot contain alphabets");
                return false;
            }
            return true;
        }

        internal static bool isValidExpiryDate(string dateString)
        {
            DateTime dateValue;
            if (DateTime.TryParse(dateString, out dateValue))
                if (dateValue < DateTime.Now)
                    return false;
                else
                    return true;
            else
                return false;
        }

        //Luhn's formula - reused code
        internal static bool IsValidCardNumber(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "");

            //FIRST STEP: Double each digit starting from the right
            int[] doubledDigits = new int[cardNumber.Length / 2];
            int k = 0;
            for (int i = cardNumber.Length - 2; i >= 0; i -= 2)
            {
                int digit = int.Parse(cardNumber[i].ToString());
                doubledDigits[k] = digit * 2;
                k++;
            }

            //SECOND STEP: Add up separate digits
            int total = 0;
            foreach (int i in doubledDigits)
            {
                string number = i.ToString();
                for (int j = 0; j < number.Length; j++)
                {
                    total += int.Parse(number[j].ToString());
                }
            }

            //THIRD STEP: Add up other digits
            int total2 = 0;
            for (int i = cardNumber.Length - 1; i >= 0; i -= 2)
            {
                int digit = int.Parse(cardNumber[i].ToString());
                total2 += digit;
            }

            //FOURTH STEP: Total
            int final = total + total2;

            return final % 10 == 0; //Well formed will divide evenly by 10
        }

        internal static bool ContainsNumbers(string value)
        {
            return Int64.TryParse(value, out Int64 result);
        }
    }
}