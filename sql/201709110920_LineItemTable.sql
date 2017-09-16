USE [Bangazon]
GO

/****** Object:  Table [dbo].[LineItem]    Script Date: 9/11/2017 7:22:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LineItem](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL
) ON [PRIMARY]
GO


