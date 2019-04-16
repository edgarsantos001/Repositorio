USE [SUPORTE_II]
GO
/****** Object:  Table [carga].[ENVOLTORIOS]    Script Date: 16/04/2019 08:13:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [carga].[ENVOLTORIOS](
	[ENVOLTORIOS_ID] [int] IDENTITY(1,1) NOT NULL,
	[ENVOLTORIOS_DESC] [varchar](500) NULL,
 CONSTRAINT [ENVOLTORIOS_ID] PRIMARY KEY CLUSTERED 
(
	[ENVOLTORIOS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
