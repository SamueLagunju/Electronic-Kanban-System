USE [Kanban System Data]
GO

/****** Object:  Table [dbo].[Stock Table]    Script Date: 2019-03-19 6:51:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Stock Table](
	[Station Number] [int] NOT NULL,
	[Harness] [int] NOT NULL,
	[Reflector] [int] NOT NULL,
	[Housing] [int] NOT NULL,
	[Lens] [int] NOT NULL,
	[Bulb] [int] NOT NULL,
	[Bezel] [int] NOT NULL,
 CONSTRAINT [PK_Stock Table] PRIMARY KEY CLUSTERED 
(
	[Station Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

