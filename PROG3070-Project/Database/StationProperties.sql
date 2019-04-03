USE [Kanban System Data]
GO

/****** Object:  Table [dbo].[StationProperties]    Script Date: 2019-04-02 9:51:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StationProperties](
	[StationNumber] [int] NOT NULL,
	[Experience] [nchar](20) NOT NULL,
	[DefectRate] [float] NOT NULL,
	[Speed] [float] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StationProperties]  WITH CHECK ADD  CONSTRAINT [FK_StationProperties_Station] FOREIGN KEY([StationNumber])
REFERENCES [dbo].[Station] ([Station])
GO

ALTER TABLE [dbo].[StationProperties] CHECK CONSTRAINT [FK_StationProperties_Station]
GO

