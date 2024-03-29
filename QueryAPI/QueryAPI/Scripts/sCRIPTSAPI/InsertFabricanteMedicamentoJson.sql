USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [carga].[InsertFabricanteMedicamentoJson]    Script Date: 08/04/2019 14:18:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [carga].[InsertFabricanteMedicamentoJson](
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
--FABRICANTE
  IF(@fab_tipo = 'N')
     BEGIN
	   IF NOT EXISTS( SELECT * FROM carga.FABRICANTE_MEDICAMENTO WHERE CNPJ = @fab_cnpj)
	   BEGIN
	      INSERT INTO carga.FABRICANTE_MEDICAMENTO(RAZAO_SOCIAL,ENDERECO,PAIS,CNPJ,UF,CIDADE)
             VALUES(@fab_razaosocial,@fab_endereco,@fab_pais, @fab_cnpj, @fab_uf, @fab_cidade)
          SET @fabricante_id = SCOPE_IDENTITY()
	   END
	   ELSE
	   BEGIN
	      SET @fabricante_id = (SELECT FABRICANTES_ID FROM carga.FABRICANTE_MEDICAMENTO WHERE CNPJ = @fab_cnpj)
	   END
    END 
ELSE
 BEGIN
    IF NOT EXISTS( SELECT * FROM carga.FABRICANTE_MEDICAMENTO WHERE RAZAO_SOCIAL = @fab_razaosocial AND PAIS = @fab_pais)
	   BEGIN
	      INSERT INTO carga.FABRICANTE_MEDICAMENTO(RAZAO_SOCIAL,ENDERECO,PAIS,CNPJ,UF,CIDADE)
             VALUES(@fab_razaosocial,@fab_endereco,@fab_pais, @fab_cnpj, @fab_uf, @fab_cidade)
          SET @fabricante_id = SCOPE_IDENTITY()
	   END
	   ELSE
	   BEGIN
	      SET @fabricante_id = (SELECT FABRICANTES_ID FROM carga.FABRICANTE_MEDICAMENTO WHERE RAZAO_SOCIAL = @fab_razaosocial AND PAIS = @fab_pais)
	    END   
 END 
  
INSERT INTO carga.FABRICANTE_APRESENTACAO(FABRICANTES_NACIONAIS_ID, APRESENTACAO_ID, TIPO_FAB)
    VALUES (@fabricante_id, @apresentacao_id, @fab_tipo) 
END
