//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CheckOutPaymentGateway
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public System.Guid TransactionId { get; set; }
        public System.Guid MerchantId { get; set; }
        public string CardNumber { get; set; }
        public System.DateTime CardExpiryDate { get; set; }
        public string CardCurrency { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime TransactionDateTime { get; set; }
        public string TransactionStatus { get; set; }
    }
}