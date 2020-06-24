USE [ruletadb]
GO

/****** Object:  Table [dbo].[ruletas]    Script Date: 24/06/2020 9:43:50 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ruletas](
	[id_ruleta] [int] IDENTITY(1,1) NOT NULL,
	[state] [bit] NULL,
	[number] [int] NULL,
	[color] [bit] NULL,
 CONSTRAINT [PK_ruletas] PRIMARY KEY CLUSTERED 
(
	[id_ruleta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


