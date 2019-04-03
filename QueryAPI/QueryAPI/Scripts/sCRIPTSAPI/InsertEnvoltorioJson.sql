USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertFabricanteJson]    Script Date: 03/04/2019 11:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [carga].[InsertEnvoltorioJson](
@env_envoltorios_desc varchar(500) = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @envoltorio_id int
--ENVOLTORIOS
INSERT INTO carga.ENVOLTORIOS(ENVOLTORIOS_DESC) VALUES (@env_envoltorios_desc)
SET @envoltorio_id = SCOPE_IDENTITY()

INSERT INTO carga.ENVOLTORIO_APRESENTACAO(ENVOLTORIOS_ID, APRESENTACAO_ID) VALUES (@envoltorio_id, @apresentacao_id) 
END
