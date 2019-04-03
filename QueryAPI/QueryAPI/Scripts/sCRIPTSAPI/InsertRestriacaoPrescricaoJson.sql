USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertFabricanteJson]    Script Date: 03/04/2019 11:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [carga].[InsertRestriacaoPrescricaoJson](
@restricao_desc varchar(500) = NULL,
@apresentacao_id int = NULL)
AS    
BEGIN
DECLARE @restricao_id int
--ROTULO
INSERT INTO carga.RESTRICAO_PRESCRICAO(RESTRICAO_PRESCRICAO_DESC) VALUES (@restricao_desc)
SET @restricao_id = SCOPE_IDENTITY()

INSERT INTO carga.RESTRICAO_PRESCRICAO_APRESENTACAO(RESTRICAO_PRESCRICAO_ID, APRESENTACAO_ID) VALUES (@restricao_id, @apresentacao_id) 
END
