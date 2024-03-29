USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [carga].[InsertRestriacaoUsoJson]    Script Date: 08/04/2019 16:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [carga].[InsertRestriacaoUsoJson](
@restricaoUso_desc varchar(500) = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @restricao_id int
--ROTULO

IF NOT EXISTS( SELECT * FROM carga.RESTRICAO_USO WHERE RESTRICAO_USO_DESC = @restricaoUso_desc)
BEGIN
    INSERT INTO carga.RESTRICAO_USO(RESTRICAO_USO_DESC) VALUES (@restricaoUso_desc)
 SET @restricao_id = SCOPE_IDENTITY()

END
ELSE 
BEGIN
SET @restricao_id = (SELECT TOP 1 RESTRICAO_USO_ID FROM carga.RESTRICAO_USO WHERE RESTRICAO_USO_DESC = @restricaoUso_desc)

END

INSERT INTO carga.RESTRICAO_US0_APRESENTACAO(RESTRICAO_USO_ID, APRESENTACAO_ID) VALUES (@restricao_id, @apresentacao_id) 
END
