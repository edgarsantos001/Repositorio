USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertFabricanteJson]    Script Date: 03/04/2019 11:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [carga].[InsertConservacaoJson](
@conservacao_desc varchar(500) = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @conservacao_id int
--CONSERVACAO
IF NOT EXISTS(SELECT * FROM carga.CONSERVACAO WHERE CONSERVACAO_DESC = @conservacao_desc)
BEGIN
INSERT INTO carga.CONSERVACAO(CONSERVACAO_DESC) VALUES (@conservacao_desc)
SET @conservacao_id = SCOPE_IDENTITY()
END
ELSE
BEGIN
SET @conservacao_id = (SELECT CONSERVACAO_ID FROM carga.CONSERVACAO WHERE CONSERVACAO_DESC = @conservacao_desc)
END

INSERT INTO carga.CONSERVACAO_APRESENTACAO(CONSERVACAO_ID, APRESENTACAO_ID) VALUES (@conservacao_id, @apresentacao_id) 
END
