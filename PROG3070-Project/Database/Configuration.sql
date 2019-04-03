USE [Kanban System Data]
GO

/****** Object:  Table [dbo].[Configuration]    Script Date: 2019-04-02 9:50:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Configuration](
	[Item] [nchar](20) NOT NULL,
	[Value] [float] NOT NULL
) ON [PRIMARY]
GO

