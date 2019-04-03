USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertFabricanteJson]    Script Date: 03/04/2019 11:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [carga].[InsertPrincipioAtivoJson](
@principio_ativo_desc varchar(500) = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @principio_ativo_id int
--ROTULO
INSERT INTO carga.PRINCIPIO_ATIVO(PRINCIPIO_ATIVO_DESC) VALUES (@principio_ativo_desc)
SET @principio_ativo_id = SCOPE_IDENTITY()

INSERT INTO carga.PRINCIPIO_ATIVO_APRESENTACAO(PRINCIPIO_ATIVO_ID, APRESENTACAO_ID) VALUES (@principio_ativo_id, @apresentacao_id) 
END
