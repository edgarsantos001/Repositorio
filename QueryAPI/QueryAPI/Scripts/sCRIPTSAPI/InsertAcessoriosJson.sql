USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertFabricanteJson]    Script Date: 03/04/2019 11:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [carga].[InsertAcessoriosJson](
@ace_acessorios_desc varchar(500) = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @acessorio_id int
--ROTULO
INSERT INTO carga.ACESSORIOS(ACESSORIOS_DESC) VALUES (@ace_acessorios_desc)
SET @acessorio_id = SCOPE_IDENTITY()

INSERT INTO carga.ACESSORIOS_APRESENTACAO(ACESSORIOS_ID, APRESENTACAO_ID) VALUES (@acessorio_id, @apresentacao_id) 
END
