USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [carga].[InsertEnvoltorioJson]    Script Date: 16/04/2019 08:13:48 ******/
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
IF NOT EXISTS(SELECT * FROM carga.ENVOLTORIOS WHERE ENVOLTORIOS_DESC = @env_envoltorios_desc)
BEGIN
INSERT INTO carga.ENVOLTORIOS(ENVOLTORIOS_DESC) VALUES (@env_envoltorios_desc)
 SET @envoltorio_id = SCOPE_IDENTITY()
END
ELSE
BEGIN
SET @envoltorio_id = (SELECT ENVOLTORIOS_ID FROM carga.ENVOLTORIOS WHERE ENVOLTORIOS_DESC = @env_envoltorios_desc)
END

INSERT INTO carga.ENVOLTORIO_APRESENTACAO(ENVOLTORIOS_ID, APRESENTACAO_ID) VALUES (@envoltorio_id, @apresentacao_id) 

END
GO
