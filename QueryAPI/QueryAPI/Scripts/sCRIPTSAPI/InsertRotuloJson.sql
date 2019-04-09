USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [carga].[InsertRotuloJson]    Script Date: 05/04/2019 14:23:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [carga].[InsertRotuloJson](
@rotulo_desc varchar(500) = NULL,
@idmedDet_id int = NULL)
AS    
BEGIN
DECLARE @rotulo_id int
--ROTULO
INSERT INTO carga.ROTULO (ROTULO_DESC) VALUES (@rotulo_desc)
SET @rotulo_id = SCOPE_IDENTITY()

INSERT INTO carga.ROTULO_MEDICAMENTO(ROTULO_ID, MEDICAMENTO_ID) VALUES (@rotulo_id, @idmedDet_id) 
END




