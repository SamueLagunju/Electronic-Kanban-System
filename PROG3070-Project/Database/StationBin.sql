USE [Kanban System Data]
GO

/****** Object:  Table [dbo].[StationBin]    Script Date: 2019-04-02 9:51:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StationBin](
	[Station] [int] NOT NULL,
	[Bin] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StationBin]  WITH CHECK ADD  CONSTRAINT [FK_StationBin_Station] FOREIGN KEY([Bin])
REFERENCES [dbo].[Bin] ([Bin])
GO

ALTER TABLE [dbo].[StationBin] CHECK CONSTRAINT [FK_StationBin_Station]
GO

