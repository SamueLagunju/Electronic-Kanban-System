USE [Kanban System Data]
GO

/****** Object:  Table [dbo].[Overseer Table]    Script Date: 2019-03-19 6:50:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Overseer Table](
	[Station Number] [int] NOT NULL,
	[Completed Products] [int] NOT NULL,
	[Defective Products] [int] NOT NULL,
	[Yield] [float] NOT NULL
) ON [PRIMARY]
GO

