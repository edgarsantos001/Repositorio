USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [carga].[InsertRestriacaoPrescricaoJson]    Script Date: 08/04/2019 16:27:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [carga].[InsertRestriacaoPrescricaoJson](
@restricao_desc varchar(500) = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @restricao_id int
--ROTULO

IF NOT EXISTS( SELECT * FROM carga.RESTRICAO_PRESCRICAO WHERE RESTRICAO_PRESCRICAO_DESC = @restricao_desc)
BEGIN
INSERT INTO carga.RESTRICAO_PRESCRICAO(RESTRICAO_PRESCRICAO_DESC) VALUES (@restricao_desc)
SET @restricao_id = SCOPE_IDENTITY()

END
ELSE 
BEGIN
SET @restricao_id = (SELECT TOP 1 RESTRICAO_PRESCRICAO_ID FROM carga.RESTRICAO_PRESCRICAO WHERE RESTRICAO_PRESCRICAO_DESC = @restricao_desc)

END

INSERT INTO carga.RESTRICAO_PRESC_APRESENTACAO(RESTRICAO_PRESCRICAO_ID, APRESENTACAO_ID) VALUES (@restricao_id, @apresentacao_id) 
END
