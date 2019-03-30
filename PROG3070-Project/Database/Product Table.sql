USE [Kanban System Data]
GO

/****** Object:  Table [dbo].[Product Table]    Script Date: 2019-03-19 6:51:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product Table](
	[Tray Number] [nchar](8) NOT NULL,
	[Lamp Number] [nchar](2) NOT NULL,
	[Station Number] [int] NOT NULL,
	[Test Result] [nchar](4) NULL,
 CONSTRAINT [PK_Product Table] PRIMARY KEY CLUSTERED 
(
	[Tray Number] ASC,
	[Lamp Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

