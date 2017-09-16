/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2016
    Target Database Engine Edition : Microsoft SQL Server Express Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [Bangazon]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 9/12/2017 8:21:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[OrderId] [int] NOT NULL,
	[OrderTotal] [money] NOT NULL,
	[Paid] [bit] NOT NULL,
	[CustomerId] [int] NOT NULL
) ON [PRIMARY]
GO


