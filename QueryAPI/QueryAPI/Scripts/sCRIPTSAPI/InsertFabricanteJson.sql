USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [carga].[InsertFabricanteJson]    Script Date: 09/04/2019 16:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [carga].[InsertFabricanteJson](

@cont_content_id int = NULL,
@fab_atividade varchar(max) = NULL,
@fab_razaosocial varchar(max) = NULL,
@fab_pais varchar(max) = NULL,
@fab_local varchar(max) = NULL
)
AS    
BEGIN
DECLARE @fabricante_id int
--MATERIAL	
IF NOT EXISTS(SELECT * FROM carga.FABRICANTE WHERE ATIVIDADE = @fab_atividade AND RAZAOSOCIAL = @fab_razaosocial AND PAIS = @fab_pais)
BEGIN
INSERT INTO carga.FABRICANTE(ATIVIDADE, RAZAOSOCIAL, PAIS, LOCAL)
    VALUES(@fab_atividade, @fab_razaosocial,@fab_pais, @fab_local)
SET @fabricante_id = SCOPE_IDENTITY()
END
ELSE
BEGIN
SET @fabricante_id = (SELECT FABRICANTE_ID FROM carga.FABRICANTE WHERE ATIVIDADE = @fab_atividade AND RAZAOSOCIAL = @fab_razaosocial AND PAIS = @fab_pais)
END

INSERT INTO carga.FABRICANTE_CONTENT(CONTENT_ID, FABRICANTE_ID)
    VALUES (@cont_content_id, @fabricante_id) 
END
