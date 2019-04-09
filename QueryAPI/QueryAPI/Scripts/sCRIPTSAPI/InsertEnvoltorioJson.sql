USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertFabricanteJson]    Script Date: 03/04/2019 11:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
<<<<<<< HEAD
ALTER PROCEDURE [carga].[InsertEnvoltorioJson](
=======
CREATE PROCEDURE [carga].[InsertEnvoltorioJson](
>>>>>>> 250e1124aac982d430b4c96b5f40c1413fb05cc0
@env_envoltorios_desc varchar(500) = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @envoltorio_id int
--ENVOLTORIOS
<<<<<<< HEAD
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

=======
INSERT INTO carga.ENVOLTORIOS(ENVOLTORIOS_DESC) VALUES (@env_envoltorios_desc)
SET @envoltorio_id = SCOPE_IDENTITY()

INSERT INTO carga.ENVOLTORIO_APRESENTACAO(ENVOLTORIOS_ID, APRESENTACAO_ID) VALUES (@envoltorio_id, @apresentacao_id) 
>>>>>>> 250e1124aac982d430b4c96b5f40c1413fb05cc0
END
