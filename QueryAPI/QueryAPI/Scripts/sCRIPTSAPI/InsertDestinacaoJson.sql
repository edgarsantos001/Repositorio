USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertFabricanteJson]    Script Date: 03/04/2019 11:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [carga].[InsertDestinacaoJson](
@destinacao_desc varchar(500) = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @destinacao_id int
--ROTULO
INSERT INTO carga.DESTINACAO(DESTINACAO_DESC) VALUES (@destinacao_desc)
SET @destinacao_id = SCOPE_IDENTITY()

INSERT INTO carga.DESTINACAO_APRESENTACAO(DESTINACAO_ID, APRESENTACAO_ID) VALUES (@destinacao_id, @apresentacao_id) 
END
