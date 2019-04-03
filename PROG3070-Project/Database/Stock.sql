USE [Kanban System Data]
GO

/****** Object:  Table [dbo].[Stock]    Script Date: 2019-04-02 9:51:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Stock](
	[Station] [int] NOT NULL,
	[Part] [int] NOT NULL,
	[Stock] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Part] FOREIGN KEY([Part])
REFERENCES [dbo].[Part] ([PartID])
GO

ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Part]
GO

ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Station] FOREIGN KEY([Station])
REFERENCES [dbo].[Station] ([Station])
GO

ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Station]
GO

