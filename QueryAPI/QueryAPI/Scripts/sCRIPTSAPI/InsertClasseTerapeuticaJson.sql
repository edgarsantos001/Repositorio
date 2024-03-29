USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [carga].[InsertClasseTerapeuticaJson]    Script Date: 05/04/2019 14:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [carga].[InsertClasseTerapeuticaJson](
@classe_terapeutica_desc varchar(300) = NULL,
@idmedDet_id int = NULL)
AS    
BEGIN
DECLARE @classe_id int
--CLASSE_TERAPEUTICO
IF NOT EXISTS(SELECT * FROM carga.CLASSE_TERAPEUTICA  WHERE CLASSE_TERAPEUTICA_DESC = @classe_terapeutica_desc)
   BEGIN
      INSERT INTO carga.CLASSE_TERAPEUTICA (CLASSE_TERAPEUTICA_DESC) VALUES (@classe_terapeutica_desc)
   SET @classe_id = SCOPE_IDENTITY()
   END
   ELSE
   BEGIN
   SET @classe_id = (SELECT CLASSE_TERAPEUTICA_ID FROM carga.CLASSE_TERAPEUTICA WHERE CLASSE_TERAPEUTICA_DESC = @classe_terapeutica_desc)
   END

  INSERT INTO carga.CLASSE_MEDICAMENTO(CLASSE_TERAPEUTICA_ID, MEDICAMENTO_ID) VALUES (@classe_id,@idmedDet_id) 
END
