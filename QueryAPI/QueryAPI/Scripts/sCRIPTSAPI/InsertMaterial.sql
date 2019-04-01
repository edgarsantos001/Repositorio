USE [SUPORTE]
GO
/****** Object:  StoredProcedure [dbo].[InsertMaterialJson]    Script Date: 28/03/2019 13:36:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[InsertMaterialJson](
--MATERIAL
@mat_totaElements int NULL,
@mat_totalpages int NULL,
@mat_lastpage bit NULL,
@mat_numberselements int NULL,
@mat_firstpage bit NULL,
@mat_sort int NULL,
@mat_number int NULL,
@mat_size int NULL)
AS    
BEGIN
DECLARE @material_id AS int

--MATERIAL
  INSERT INTO MATERIAL ( TOTALELEMENTS, TOTALPAGES, LASTPAGE, NUMBERSELEMENTS, FIRSTPAGE, SORT, NUMBER, SIZE)
    VALUES(@mat_totaElements, @mat_totalpages,@mat_lastpage, @mat_numberselements, @mat_firstpage, @mat_sort, @mat_number, @mat_size)

SET @material_id  = SCOPE_IDENTITY()

SELECT @material_id AS MATERIAL_ID

RETURN;	
END
