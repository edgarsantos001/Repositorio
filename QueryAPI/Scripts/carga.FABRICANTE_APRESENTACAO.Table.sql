USE [SUPORTE_II]
GO
/****** Object:  Table [carga].[FABRICANTE_APRESENTACAO]    Script Date: 16/04/2019 08:13:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [carga].[FABRICANTE_APRESENTACAO](
	[FABRICANTES_NACIONAIS_ID] [int] NULL,
	[APRESENTACAO_ID] [int] NULL,
	[TIPO_FAB] [char](1) NULL
) ON [PRIMARY]
GO
ALTER TABLE [carga].[FABRICANTE_APRESENTACAO]  WITH CHECK ADD  CONSTRAINT [FK_APRES_FAB] FOREIGN KEY([APRESENTACAO_ID])
REFERENCES [carga].[APRESENTACAO] ([APRESENTACAO_ID])
GO
ALTER TABLE [carga].[FABRICANTE_APRESENTACAO] CHECK CONSTRAINT [FK_APRES_FAB]
GO
ALTER TABLE [carga].[FABRICANTE_APRESENTACAO]  WITH CHECK ADD  CONSTRAINT [FK_FAB_APRES] FOREIGN KEY([FABRICANTES_NACIONAIS_ID])
REFERENCES [carga].[FABRICANTE_MEDICAMENTO] ([FABRICANTES_ID])
GO
ALTER TABLE [carga].[FABRICANTE_APRESENTACAO] CHECK CONSTRAINT [FK_FAB_APRES]
GO
