USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertFabricanteJson]    Script Date: 03/04/2019 11:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [carga].[InsertFormasFarmaceuticasJson](
@formas_desc varchar(500) = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @formas_id int
--ROTULO
INSERT INTO carga.FORMAS_FARMACEUTICAS(FORMAS_FARMACEUTICAS_DESC) VALUES (@formas_desc)
SET @formas_id = SCOPE_IDENTITY()

INSERT INTO carga.FORMAS_APRESENTACAO(FORMAS_FARMACEUTICAS_ID, APRESENTACAO_ID) VALUES (@formas_id, @apresentacao_id) 
END