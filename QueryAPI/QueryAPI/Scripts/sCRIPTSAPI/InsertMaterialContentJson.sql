USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertMaterialContentJson]    Script Date: 09/04/2019 13:30:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [carga].[InsertMaterialContentJson](

@material_id int NULL,
--EMPRESA
@emp_cnpj varchar(20) NULL,
@emp_razaoSocial varchar(2000) = NULL,
@emp_numeroAutorizacao int = NULL,
@emp_cnpjFormatado varchar(20) = NULL,
@emp_autorizacao varchar(2000) = NULL,

--VENCIMENTO
@ven_data date = NULL, 
@ven_descricao varchar(2000) = NULL,

--MENSAGEM
@msg_situacao varchar(2000) = NULL,
@msg_resolucao varchar(2000) = NULL,
@msg_motivo varchar(2000) = NULL,
@msg_negativo bit = NULL,
 
 --CLASSE_RISCO
 @clr_sigla varchar(5) = NULL ,
 @clr_descricao varchar(500) = NULL,

--CONTENT_MATERIAL
 @cont_processo varchar(40) = NULL,
 @cont_descproduto varchar(max) = NULL,
 @cont_codanv numeric(18,0) = NULL,
 @cont_situacao varchar(4000) = NULL,
 @cont_nomeTecnico varchar(4000) = NULL,
 @cont_cancelado bit = NULL,
 @cont_dataCancelamento date = NULL ,
 @cont_publicacao date = NULL,
 @cont_apresentacaoModelo bit = NULL
 )

AS    

BEGIN
DECLARE @empresa_id AS int
DECLARE @vencimento_Id AS int
DECLARE @msg_Id AS int
DECLARE @clr_id AS int 


IF NOT EXISTS (SELECT * FROM CONTENT_MATERIAL WHERE PROCESSO = @cont_processo)
BEGIN
	--EMPRESA
	IF NOT EXISTS(SELECT * FROM EMPRESA WHERE CNPJ = @emp_cnpj)
	BEGIN 
	INSERT INTO EMPRESA (CNPJ, RAZAO_SOCIAL, NUMEROAUTORIZACAO, CNPJFORMATADO, AUTORIZACAO)
	  VALUES(@emp_cnpj, @emp_razaoSocial, @emp_numeroAutorizacao, @emp_cnpjFormatado, @emp_autorizacao)
	SET @empresa_id  = SCOPE_IDENTITY()
	END
	ELSE 
	BEGIN
	SET @empresa_id = (SELECT ID_EMPRESA FROM EMPRESA WHERE CNPJ = @emp_cnpj)
	END
	
	--VENCIMENTO
	INSERT INTO VENCIMENTO( DATA, DESCRICAO)
	  VALUES(@ven_data, @ven_descricao)
	
	SET @vencimento_Id  = SCOPE_IDENTITY()
	
	--MENSAGEM

	IF( @msg_situacao IS NOT NULL AND @msg_resolucao IS NOT NULL AND @msg_motivo IS NOT NULL)
	BEGIN
	INSERT INTO MENSAGEM (SITUACAO, RESOLUCAO, MOTIVO, NEGATIVO)
	  VALUES( @msg_situacao , @msg_resolucao,@msg_motivo, @msg_negativo)		  
	
	SET @msg_Id  = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
	SET @msg_Id = 0
  END
	
	--CLASSE_RISCO
	IF NOT EXISTS(SELECT * FROM carga.CLASSE_RISCO WHERE SIGLA = @clr_sigla AND DESCRICAO =@clr_descricao)
	BEGIN
	INSERT INTO CLASSE_RISCO (SIGLA, DESCRICAO)
	VALUES (@clr_sigla, @clr_descricao)
	SET @clr_id = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
	SET @clr_id = (SELECT CLASSE_RISCO_ID FROM carga.CLASSE_RISCO WHERE SIGLA = @clr_sigla AND DESCRICAO =@clr_descricao)
	END

	--CONTENT_MATERIAL
	INSERT INTO CONTENT_MATERIAL(MATERIAL_ID, EMPRESA_ID, MSG_ID, VENCIMENTO_ID, CLASSE_RISCO_ID, PROCESSO, DESC_PRODUTO, COD_ANV, SITUACAO, NOME_TECNICO,CANCELADO, DATA_CANCELAMENTO, PUBLICACAO, APRESENTACAOMODELO)
	VALUES( @material_id,@empresa_id, @msg_Id, @vencimento_Id, @clr_id, @cont_processo, @cont_descproduto, @cont_codanv,@cont_situacao, 
	        @cont_nomeTecnico, @cont_cancelado, @cont_dataCancelamento, @cont_publicacao, @cont_apresentacaoModelo)
	
	DECLARE @content_id AS int
	SET @content_id = SCOPE_IDENTITY()
	
	SELECT @content_id AS CONTENT_ID
	
	RETURN;	
END
ELSE 
BEGIN 
	SELECT 0 AS CONTENT_ID
	RETURN;	
END
END
