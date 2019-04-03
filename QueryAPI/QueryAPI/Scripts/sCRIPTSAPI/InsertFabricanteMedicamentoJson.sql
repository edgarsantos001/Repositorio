USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertFabricanteJson]    Script Date: 03/04/2019 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [carga].[InsertFabricanteMedicamentoJson](
@apresentacao_id int = NULL,
@fab_razaosocial varchar(4000) = NULL,
@fab_endereco varchar(500) = NULL,
@fab_pais varchar(200) = NULL,
@fab_cnpj varchar(200) = NULL,
@fab_cidade varchar(200) = NULL,
@fab_uf varchar(10) = NULL,
@fab_tipo char = NULL
)
AS    
BEGIN
DECLARE @fabricante_id int
--MATERIAL	
  INSERT INTO FABRICANTE_MEDICAMENTO(RAZAO_SOCIAL,ENDERECO,PAIS,CNPJ,UF,CIDADE)
    VALUES(@fab_razaosocial,@fab_endereco,@fab_pais, @fab_cnpj, @fab_uf, @fab_cidade)
SET @fabricante_id = SCOPE_IDENTITY()

INSERT INTO FABRICANTE_APRESENTACAO(FABRICANTES_NACIONAIS_ID, APRESENTACAO_ID, TIPO_FAB)
    VALUES (@fabricante_id, @apresentacao_id, @fab_tipo) 
END
