USE [SUPORTE_II]
GO
/****** Object:  Table [carga].[MATERIAL]    Script Date: 16/04/2019 08:13:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [carga].[MATERIAL](
	[ID_MATERIAL] [int] IDENTITY(1,1) NOT NULL,
	[TOTALELEMENTS] [int] NULL,
	[TOTALPAGES] [int] NULL,
	[LASTPAGE] [bit] NULL,
	[NUMBERSELEMENTS] [int] NULL,
	[FIRSTPAGE] [bit] NULL,
	[SORT] [int] NULL,
	[NUMBER] [int] NULL,
	[SIZE] [int] NULL,
 CONSTRAINT [ID_MATERIAL] PRIMARY KEY CLUSTERED 
(
	[ID_MATERIAL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
