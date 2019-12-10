USE [master]
GO

CREATE DATABASE [AcquiringBankDB]
GO
USE [AcquiringBankDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcquiringBankDBAccount](
	[AcquiringBankId] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[IsSuccess][bit] NOT NULL,
	[LastModifiedTimeStamp][datetime] NOT NULL,
 CONSTRAINT [PK_AcquiringBankDBAccount] PRIMARY KEY CLUSTERED 
(
	[AcquiringBankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
