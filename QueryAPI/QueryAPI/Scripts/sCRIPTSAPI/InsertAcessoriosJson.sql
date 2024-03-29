USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [carga].[InsertAcessoriosJson]    Script Date: 08/04/2019 15:42:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [carga].[InsertAcessoriosJson](
@acessorios_desc varchar(500) = NULL,
@acessorios_qtd int = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @acessorio_id int
--ROTULO
      IF NOT EXISTS(SELECT * FROM carga.ACESSORIOS WHERE ACESSORIOS_DESC = @acessorios_desc AND ACESSORIOS_QTD = @acessorios_qtd)
      BEGIN
      INSERT INTO carga.ACESSORIOS(ACESSORIOS_DESC, ACESSORIOS_QTD) VALUES (@acessorios_desc,@acessorios_qtd )
      SET @acessorio_id = SCOPE_IDENTITY()
      END
      ELSE
      BEGIN
      SET @acessorio_id = (SELECT ACESSORIOS_ID FROM carga.ACESSORIOS WHERE ACESSORIOS_DESC = @acessorios_desc AND ACESSORIOS_QTD = @acessorios_qtd)
      END
      INSERT INTO carga.ACESSORIOS_APRESENTACAO(ACESSORIOS_ID, APRESENTACAO_ID) VALUES (@acessorio_id, @apresentacao_id) 
END
