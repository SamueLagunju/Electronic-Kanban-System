USE [Kanban System Data]
GO

/****** Object:  Table [dbo].[Bin]    Script Date: 2019-04-02 9:50:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bin](
	[Bin] [int] NOT NULL,
	[Part] [int] NOT NULL,
	[Capacity] [int] NOT NULL,
 CONSTRAINT [PK_Bin_1] PRIMARY KEY CLUSTERED 
(
	[Bin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Bin]  WITH CHECK ADD  CONSTRAINT [FK_Bin_Part] FOREIGN KEY([Part])
REFERENCES [dbo].[Part] ([PartID])
GO

ALTER TABLE [dbo].[Bin] CHECK CONSTRAINT [FK_Bin_Part]
GO

