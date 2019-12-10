
USE [CheckOutPaymentGateway]
GO
CREATE TABLE [dbo].[Transaction](
	[TransactionId] [uniqueidentifier] NOT NULL,
	[MerchantId] [uniqueidentifier] NOT NULL,
	[CardNumber] [nvarchar](20) NOT NULL,
	[CardExpiryDate] [datetime] NOT NULL,
	[CardCurrency] [nvarchar](15) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[TransactionDateTime] [datetime] NOT NULL,
	[TransactionStatus] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO