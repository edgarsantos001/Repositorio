USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertFabricanteJson]    Script Date: 03/04/2019 11:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [carga].[InsertMarcaJson](
@marca_desc varchar(500) = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @marca_id int
--ROTULO
INSERT INTO carga.MARCA(MARCA_DESC) VALUES (@marca_desc)
SET @marca_id = SCOPE_IDENTITY()

INSERT INTO carga.MARCA_APRESENTACAO(MARCA_ID, APRESENTACAO_ID) VALUES (@marca_id, @apresentacao_id) 
END
