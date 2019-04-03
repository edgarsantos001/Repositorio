USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertFabricanteJson]    Script Date: 03/04/2019 11:08:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [carga].[InsertRotuloJson](
@rotulo_desc varchar(500) = NULL,
@med_id int = NULL)
AS    
BEGIN
DECLARE @rotulo_id int
--ROTULO
INSERT INTO carga.ROTULO (ROTULO_DESC) VALUES (@rotulo_desc)
SET @rotulo_id = SCOPE_IDENTITY()

INSERT INTO carga.ROTULO_MEDICAMENTO(ROTULO_ID, MEDICAMENTO_ID) VALUES (@rotulo_id, @med_id) 
END




