USE [Kanban System Data]
GO

/****** Object:  Table [dbo].[Kanban Table]    Script Date: 2019-03-19 6:50:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Kanban Table](
	[Station Number] [int] NOT NULL,
	[Part] [nchar](10) NOT NULL,
	[Status] [nchar](8) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Kanban Table] ADD  CONSTRAINT [DF_Kanban Table_Status]  DEFAULT (N'Pending') FOR [Status]
GO

