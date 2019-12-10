namespace CheckOutPaymentGatewayClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ExpiryDate = new System.Windows.Forms.TextBox();
            this.Currency = new System.Windows.Forms.TextBox();
            this.CVV = new System.Windows.Forms.TextBox();
            this.CardNumber = new System.Windows.Forms.TextBox();
            this.Amount = new System.Windows.Forms.TextBox();
            this.MerchantId = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProcessPayment = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblMerchantId = new System.Windows.Forms.Label();
            this.txtMerchantId = new System.Windows.Forms.TextBox();
            this.btnRetrieveDetails = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1025, 619);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ExpiryDate);
            this.tabPage1.Controls.Add(this.Currency);
            this.tabPage1.Controls.Add(this.CVV);
            this.tabPage1.Controls.Add(this.CardNumber);
            this.tabPage1.Controls.Add(this.Amount);
            this.tabPage1.Controls.Add(this.MerchantId);
            this.tabPage1.Controls.Add(this.lblStatus);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnProcessPayment);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1017, 593);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Process Payment";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ExpiryDate
            // 
            this.ExpiryDate.Location = new System.Drawing.Point(378, 230);
            this.ExpiryDate.Name = "ExpiryDate";
            this.ExpiryDate.Size = new System.Drawing.Size(307, 26);
            this.ExpiryDate.TabIndex = 14;
            // 
            // Currency
            // 
            this.Currency.Location = new System.Drawing.Point(378, 193);
            this.Currency.Name = "Currency";
            this.Currency.Size = new System.Drawing.Size(307, 26);
            this.Currency.TabIndex = 13;
            // 
            // CVV
            // 
            this.CVV.Location = new System.Drawing.Point(378, 161);
            this.CVV.Name = "CVV";
            this.CVV.Size = new System.Drawing.Size(307, 26);
            this.CVV.TabIndex = 12;
            // 
            // CardNumber
            // 
            this.CardNumber.Location = new System.Drawing.Point(378, 126);
            this.CardNumber.Name = "CardNumber";
            this.CardNumber.Size = new System.Drawing.Size(307, 26);
            this.CardNumber.TabIndex = 11;
            // 
            // Amount
            // 
            this.Amount.Location = new System.Drawing.Point(378, 92);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(307, 26);
            this.Amount.TabIndex = 10;
            // 
            // MerchantId
            // 
            this.MerchantId.Location = new System.Drawing.Point(378, 57);
            this.MerchantId.Name = "MerchantId";
            this.MerchantId.Size = new System.Drawing.Size(307, 26);
            this.MerchantId.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(216, 413);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(62, 16);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Waiting...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(150, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Status:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(150, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Expiry Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(150, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Currency";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(150, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Card Verification Value (CVV)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Card Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Merchant Id";
            // 
            // btnProcessPayment
            // 
            this.btnProcessPayment.Location = new System.Drawing.Point(431, 313);
            this.btnProcessPayment.Name = "btnProcessPayment";
            this.btnProcessPayment.Size = new System.Drawing.Size(229, 40);
            this.btnProcessPayment.TabIndex = 0;
            this.btnProcessPayment.Text = "Process Payment";
            this.btnProcessPayment.UseVisualStyleBackColor = true;
            this.btnProcessPayment.Click += new System.EventHandler(this.btnProcessPayment_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox);
            this.tabPage2.Controls.Add(this.lblMerchantId);
            this.tabPage2.Controls.Add(this.txtMerchantId);
            this.tabPage2.Controls.Add(this.btnRetrieveDetails);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1017, 593);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Retrieve Details";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblMerchantId
            // 
            this.lblMerchantId.AutoSize = true;
            this.lblMerchantId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMerchantId.Location = new System.Drawing.Point(54, 44);
            this.lblMerchantId.Name = "lblMerchantId";
            this.lblMerchantId.Size = new System.Drawing.Size(94, 20);
            this.lblMerchantId.TabIndex = 2;
            this.lblMerchantId.Text = "Merchant Id";
            // 
            // txtMerchantId
            // 
            this.txtMerchantId.Location = new System.Drawing.Point(168, 44);
            this.txtMerchantId.Name = "txtMerchantId";
            this.txtMerchantId.Size = new System.Drawing.Size(198, 20);
            this.txtMerchantId.TabIndex = 1;
            // 
            // btnRetrieveDetails
            // 
            this.btnRetrieveDetails.Location = new System.Drawing.Point(425, 36);
            this.btnRetrieveDetails.Name = "btnRetrieveDetails";
            this.btnRetrieveDetails.Size = new System.Drawing.Size(156, 34);
            this.btnRetrieveDetails.TabIndex = 0;
            this.btnRetrieveDetails.Text = "Retrieve Details";
            this.btnRetrieveDetails.UseVisualStyleBackColor = true;
            this.btnRetrieveDetails.Click += new System.EventHandler(this.btnRetrieveDetails_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(58, 104);
            this.listBox.MultiColumn = true;
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(895, 420);
            this.listBox.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 653);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnProcessPayment;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblMerchantId;
        private System.Windows.Forms.TextBox txtMerchantId;
        private System.Windows.Forms.Button btnRetrieveDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ExpiryDate;
        private System.Windows.Forms.TextBox Currency;
        private System.Windows.Forms.TextBox CVV;
        private System.Windows.Forms.TextBox CardNumber;
        private System.Windows.Forms.TextBox Amount;
        private System.Windows.Forms.TextBox MerchantId;
        private System.Windows.Forms.ListBox listBox;
    }
}

