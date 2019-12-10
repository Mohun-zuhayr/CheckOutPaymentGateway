using CheckOutPaymentGatewayWrapper.Expo;
using CheckOutPaymentGatewayWrapper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckOutPaymentGatewayClient
{
    public partial class Form1 : Form
    {
        PaymentGatewayExpo expo = new PaymentGatewayExpo();
        private static Regex isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            //DIRTY CODES AHEAD :D 

            if (tabControl1.SelectedTab == tabPage1)
            {
                ProcessPaymentAPIModel model = new ProcessPaymentAPIModel();
                NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
                decimal amount;

                if (MerchantId.Text.Trim() == string.Empty || CardNumber.Text.Trim() == string.Empty
                    || ExpiryDate.Text.Trim() == string.Empty || Amount.Text.Trim() == string.Empty
                    || Currency.Text.Trim() == string.Empty || CVV.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("All fields are required for process the payment!");
                    return;

                }

                if (IsGuid(MerchantId.Text))
                {
                    model.MerchantId = Guid.Parse(MerchantId.Text);
                }
                else
                {
                    MessageBox.Show("Invalid Merchant Id!");
                    return;
                }

                if (IsValidCardNumber(CardNumber.Text))
                {
                    model.CardNumber = CardNumber.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Card Number!");
                    return;
                }


                if (isValidExpiryDate(ExpiryDate.Text))
                {
                    model.ExpiryDate = Convert.ToDateTime(ExpiryDate.Text);
                }
                else
                {
                    MessageBox.Show("Invalid Expiry Date");
                    return;
                }

                if (Decimal.TryParse(Amount.Text, style, culture, out amount))
                {
                    model.Amount = amount;
                }
                else
                {
                    MessageBox.Show("Invalid Amount");
                    return;
                }


                //can add more validations...
                model.Currency = Currency.Text;
                model.CVV = CVV.Text;

                var response = expo.ProcessPayment(model);
                lblStatus.Text = !string.IsNullOrEmpty(response.ResponseMessage) ?
                    response.ResponseStatus.ToString() + " : " + response.ResponseMessage.ToString() : response.ResponseStatus.ToString(); 
            }
        }

        private void btnRetrieveDetails_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                if (txtMerchantId.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Merchant Id is required!");
                    return;

                }

                if (!IsGuid(txtMerchantId.Text))
                {
                    MessageBox.Show("Invalid Merchant Id!");
                    return;
                }

                List<TransactionAPIModel> models = expo.GetTransactions(Guid.Parse(txtMerchantId.Text));
                if (models.Count > 0)
                {
                    listBox.BeginUpdate();
                    foreach (TransactionAPIModel model in models)
                    {
                        listBox.Items.Add("Merchant Id : " + txtMerchantId.Text);
                        listBox.Items.Add("Masked Card Number : " + model.MaskedCardNumber.ToString());
                        listBox.Items.Add("Card Expiry Date : " + model.CardExpiryDate.ToString());
                        listBox.Items.Add("Card Currency : " + model.CardCurrency.ToString());
                        listBox.Items.Add("Amount : " + model.Amount.ToString());
                        listBox.Items.Add("Transaction Time : " + model.TransactionDateTime.ToString());
                        listBox.Items.Add("_________________________________________________________");

                    }
                    listBox.EndUpdate();
                }
                
            }
        }

        internal static bool IsGuid(string candidate)
        {
            if (candidate != null)
            {
                if (isGuid.IsMatch(candidate))
                {
                    return true;
                }
            }
            return false;
        }

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
    }
}
