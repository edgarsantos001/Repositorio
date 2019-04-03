USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertFabricanteJson]    Script Date: 03/04/2019 11:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [carga].[InsertAdministracaoJson](
@administracao_desc varchar(500) = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @administracao_id int
--ROTULO
INSERT INTO carga.ADMINISTRACAO(ADMINISTRACAO_DESC) VALUES (@administracao_desc)
SET @administracao_id = SCOPE_IDENTITY()

INSERT INTO carga.ADMINISTRACAO_APRESENTACAO(ADMINISTRACAO_ID, APRESENTACAO_ID) VALUES (@administracao_id, @apresentacao_id) 
END
