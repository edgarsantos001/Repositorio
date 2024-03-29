USE [SUPORTE_II]
GO
/****** Object:  Table [carga].[ACESSORIOS_APRESENTACAO]    Script Date: 16/04/2019 08:13:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [carga].[ACESSORIOS_APRESENTACAO](
	[ACESSORIOS_ID] [int] NULL,
	[APRESENTACAO_ID] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [carga].[ACESSORIOS_APRESENTACAO]  WITH CHECK ADD  CONSTRAINT [FK_ACESSORIOS_APRES] FOREIGN KEY([ACESSORIOS_ID])
REFERENCES [carga].[ACESSORIOS] ([ACESSORIOS_ID])
GO
ALTER TABLE [carga].[ACESSORIOS_APRESENTACAO] CHECK CONSTRAINT [FK_ACESSORIOS_APRES]
GO
ALTER TABLE [carga].[ACESSORIOS_APRESENTACAO]  WITH CHECK ADD  CONSTRAINT [FK_APRES_ACESSORIOS] FOREIGN KEY([APRESENTACAO_ID])
REFERENCES [carga].[APRESENTACAO] ([APRESENTACAO_ID])
GO
ALTER TABLE [carga].[ACESSORIOS_APRESENTACAO] CHECK CONSTRAINT [FK_APRES_ACESSORIOS]
GO
