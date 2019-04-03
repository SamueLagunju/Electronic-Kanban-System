USE [Kanban System Data]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 2019-04-02 9:50:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[TrayNumber] [nchar](8) NOT NULL,
	[LampNumber] [nchar](2) NOT NULL,
	[StationNumber] [int] NOT NULL,
	[TestResult] [nchar](4) NULL,
 CONSTRAINT [PK_Product Table] PRIMARY KEY CLUSTERED 
(
	[TrayNumber] ASC,
	[LampNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Station] FOREIGN KEY([StationNumber])
REFERENCES [dbo].[Station] ([Station])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Station]
GO

