USE [Kanban System Data]
GO

/****** Object:  Table [dbo].[Station Config Table]    Script Date: 2019-03-19 6:51:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Station Config Table](
	[Station Number] [int] NOT NULL,
	[Experience] [nchar](12) NOT NULL,
	[Defect Rate] [float] NOT NULL,
	[Speed] [float] NOT NULL,
	[Harness Capacity] [int] NOT NULL,
	[Reflector Capacity] [int] NOT NULL,
	[Housing Capacity] [int] NOT NULL,
	[Lens Capacity] [int] NOT NULL,
	[Bulb Capacity] [int] NOT NULL,
	[Bezel Capacity] [int] NOT NULL
) ON [PRIMARY]
GO

