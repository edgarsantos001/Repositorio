USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [dbo].[InsertMedicamentoJson]    Script Date: 16/04/2019 08:13:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertMedicamentoJson](

--EMPRESA
 @emp_cnpj varchar(20) NULL
,@emp_razaoSocial varchar(2000) = NULL
,@emp_numeroAutorizacao int = NULL
,@emp_cnpjFormatado varchar(20) = NULL
,@emp_autorizacao varchar(2000) = NULL

--PROCESSO
,@proc_numero_processo numeric(18,0) = NULL
,@proc_situacao numeric(18,0) = NULL
,@proc_processo_formatado varchar(300) = NULL

--MEDICAMENTO
,@med_codigo_prod int = NULL 
,@med_tipo_prod	int = NULL
,@med_data_prod	date = NULL
,@med_nome_comercial varchar(max) = NULL
,@med_cod_anvisa_med numeric(18,0)
,@med_data_vencimento date = NULL
,@med_mes_ano_vencimento varchar(10) = NULL
,@med_cod_parecer_publico varchar(50) = NULL
,@med_cod_bula_pacientes varchar(2000) = NULL
,@med_cod_bula_profissional varchar(2000) = NULL
,@med_data_vencimento_registro date = NULL
,@med_principio_ativo varchar(200) = NULL 
,@med_medicamento_referencia varchar(200) = NULL
,@med_categoria_regulatoria varchar(200) = NULL
,@med_atc varchar(100) = NULL

)
AS    
BEGIN
DECLARE @med_id AS int
DECLARE @empresa_id AS int
DECLARE @processo_id AS int

IF NOT EXISTS (SELECT * FROM carga.PROCESSO WHERE NUMERO_PROCESSO = @proc_numero_processo)
BEGIN
--EMPRESA
	IF NOT EXISTS(SELECT * FROM carga.EMPRESA WHERE CNPJ = @emp_cnpj)
	BEGIN 
	INSERT INTO carga.EMPRESA (CNPJ, RAZAO_SOCIAL, NUMEROAUTORIZACAO, CNPJFORMATADO, AUTORIZACAO)
	  VALUES(@emp_cnpj, @emp_razaoSocial, @emp_numeroAutorizacao, @emp_cnpjFormatado, @emp_autorizacao)
	SET @empresa_id  = SCOPE_IDENTITY()
	END
	ELSE 
	BEGIN
	SET @empresa_id = (SELECT ID_EMPRESA FROM carga.EMPRESA WHERE CNPJ = @emp_cnpj)
	END

	--PROCESSO
	INSERT INTO [carga].[PROCESSO]
           ([NUMERO_PROCESSO]
           ,[SITUACAO]
           ,[PROCESSO_FORMATADO])
     VALUES
           (@proc_numero_processo 
		   ,@proc_situacao 
		   ,@proc_processo_formatado )
	
	SET @processo_id = SCOPE_IDENTITY()

--MEDICAMENTO
 INSERT INTO [carga].[MEDICAMENTO_CONTENT]
           ([PROCESSO_ID]
		   ,[ID_EMPRESA]
		   ,[CODIGO_PROD]
		   ,[TIPO_PROD]
           ,[DATA_PROD]
		   ,[NOME_COMERCIAL]
		   ,[COD_ANVISA_MED]
		   ,[DATA_VENCIMENTO]
		   ,[MES_ANO_VENCIMENTO]
		   ,[COD_PARECER_PUBLICO]
           ,[COD_BULA_PACIENTES]
		   ,[COD_BULA_PROFISSIONAL]
		   ,[DATA_VENCIMENTO_REGISTRO]
		   ,[PRINCIPIO_ATIVO]
		   ,[MEDICAMENTO_REFERENCIA]
		   ,[CATEGORIA_TERAPEUTICA]
		   ,[ATC]
           )
     VALUES
           (@processo_id
		   ,@empresa_id 			  
		   ,@med_codigo_prod
		   ,@med_tipo_prod
		   ,@med_data_prod
		   ,@med_nome_comercial		  
		   ,@med_cod_anvisa_med
		   ,@med_data_vencimento
		   ,@med_mes_ano_vencimento
		   ,@med_cod_parecer_publico     
		   ,@med_cod_bula_pacientes
		   ,@med_cod_bula_profissional
		   ,@med_data_vencimento_registro
		   ,@med_principio_ativo
		   ,@med_medicamento_referencia
		   ,@med_categoria_regulatoria 
		   ,@med_atc)

SET @med_id = SCOPE_IDENTITY()

SELECT @med_id AS MEDICAMENTO_ID

RETURN;	
END
ELSE
BEGIN
  SELECT 0 AS MEDICAMENTO_ID
 RETURN;	

END
END
GO
