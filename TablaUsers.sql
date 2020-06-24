USE [ruletadb]
GO

/****** Object:  Table [dbo].[users]    Script Date: 24/06/2020 9:43:59 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[users](
	[id_user] [nvarchar](50) NOT NULL,
	[cash] [int] NULL,
	[bet] [int] NULL,
	[id_ruleta] [int] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_ruletas] FOREIGN KEY([id_ruleta])
REFERENCES [dbo].[ruletas] ([id_ruleta])
GO

ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_ruletas]
GO


