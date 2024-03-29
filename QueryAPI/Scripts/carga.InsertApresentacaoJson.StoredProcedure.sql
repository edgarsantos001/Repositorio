USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [carga].[InsertApresentacaoJson]    Script Date: 16/04/2019 08:13:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [carga].[InsertApresentacaoJson](

@cont_content_id int NULL,
@ap_modelo varchar(max) NULL,
@ap_componente varchar(max) NULL,
@ap_apresentacao varchar(max) NULL
)
AS    
BEGIN
DECLARE @apresentacao_id int
--MATERIAL	
  INSERT INTO APRESENTACAOMATERIAL(MODELO, COMPONENTE, APRESENTACAO)
    VALUES(@ap_modelo, @ap_componente, @ap_apresentacao)
SET @apresentacao_id = SCOPE_IDENTITY()

INSERT INTO APRESENTACAO_CONTENT(CONTENT_ID, APRESENTACAO_ID)
    VALUES (@cont_content_id, @apresentacao_id) 
	
END
GO
