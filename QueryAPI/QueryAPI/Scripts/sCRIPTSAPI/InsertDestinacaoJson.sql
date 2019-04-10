USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertFabricanteJson]    Script Date: 03/04/2019 11:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [carga].[InsertDestinacaoJson](
@destinacao_desc varchar(500) = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @destinacao_id int
--ROTULO
IF NOT EXISTS(SELECT * FROM carga.DESTINACAO WHERE DESTINACAO_DESC = @destinacao_desc)
BEGIN
	INSERT INTO carga.DESTINACAO(DESTINACAO_DESC) VALUES (@destinacao_desc)
    SET @destinacao_id = SCOPE_IDENTITY()
END
ELSE
BEGIN
   SET @destinacao_id = (SELECT DESTINACAO_ID FROM carga.DESTINACAO WHERE DESTINACAO_DESC = @destinacao_desc)
END
INSERT INTO carga.DESTINACAO_APRESENTACAO(DESTINACAO_ID, APRESENTACAO_ID) VALUES (@destinacao_id, @apresentacao_id) 
END
