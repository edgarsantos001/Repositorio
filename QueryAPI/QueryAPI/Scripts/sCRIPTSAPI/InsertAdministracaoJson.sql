USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertFabricanteJson]    Script Date: 03/04/2019 11:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
<<<<<<< HEAD
ALTER PROCEDURE [carga].[InsertAdministracaoJson](
=======
CREATE PROCEDURE [carga].[InsertAdministracaoJson](
>>>>>>> 250e1124aac982d430b4c96b5f40c1413fb05cc0
@administracao_desc varchar(500) = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @administracao_id int
--ROTULO
<<<<<<< HEAD
IF NOT EXISTS(SELECT * FROM carga.ADMINISTRACAO  WHERE ADMINISTRACAO_DESC = @administracao_desc)
BEGIN 
INSERT INTO carga.ADMINISTRACAO(ADMINISTRACAO_DESC) VALUES (@administracao_desc)
SET @administracao_id = SCOPE_IDENTITY()
END 
ELSE 
BEGIN 
 SET @administracao_id = (SELECT ADMINISTRACAO_ID FROM carga.ADMINISTRACAO WHERE ADMINISTRACAO_DESC = @administracao_desc)
END
=======
INSERT INTO carga.ADMINISTRACAO(ADMINISTRACAO_DESC) VALUES (@administracao_desc)
SET @administracao_id = SCOPE_IDENTITY()
>>>>>>> 250e1124aac982d430b4c96b5f40c1413fb05cc0

INSERT INTO carga.ADMINISTRACAO_APRESENTACAO(ADMINISTRACAO_ID, APRESENTACAO_ID) VALUES (@administracao_id, @apresentacao_id) 
END
