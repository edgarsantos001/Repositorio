USE [SUPORTE_II]
GO
/****** Object:  StoredProcedure [carga].[InsertApresentacaoMedicamentoJson]    Script Date: 08/04/2019 09:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [carga].[InsertApresentacaoMedicamentoJson](
  @med_id int,
--EMBALAGEM
  @embp_tipo varchar(200) = '',
  @embp_observacao varchar(200) = '',

--EMBALAGEM Secundaria
 @embs_tipo varchar(200) = '',
 @embs_observacao varchar(200) = '',
--APRESENTACAO
  @apres_codigo int = NULL,
  @apres_numero int = NULL,
  @apres_totalidade int = NULL,
  @apres_apresentacao varchar(2000) = NULL,
  @apres_dataPublicacao date = NULL,
  @apres_validade int = NULL,
    
  @apres_tipoValidade int = NULL,
  @apres_registro numeric(18,0),
  @apres_acondicionamento varchar(200) = NULL,
  @apres_complemento varchar(2000) = NULL,
  @apres_restricaoHospitais bit = 0,
  @apres_tarja varchar(20) = NULL,
  @apres_medicamentoReferencia bit = 0,
  @apres_apresentacaoFracionada bit = 0,
  @apres_dataVencimentoRegistro date = NULL,
  @apres_ativa bit = NULL,
  @apres_inativa bit = NULL,
  @apres_emAnalise bit = NULL,
  @apres_ifaUnico bit = NULL)
  
AS    
BEGIN
DECLARE @embp_id AS int
DECLARE @embs_id AS int
DECLARE @apresentacao_id AS int
 
--SET @med_id = 1 
----EMBALAGEM
--SET  @embp_tipo = 'Frasco de plástico opaco'
--SET  @embp_observacao = NULL

----EMBALAGEM Secundaria
--SET @embs_tipo = 'Cartucho'
--SET @embs_observacao = 'Cartolina'
----APRESENTACAO
--SET @apres_codigo = 1
--SET @apres_numero = 1
--SET @apres_totalidade = 0  --'','',0,0,0,0,null,1,0,1
--SET @apres_apresentacao = 'TESTE 1000 ML'
--SET @apres_dataPublicacao = '2019-03-25'
--SET @apres_validade = 24
--SET @apres_tipoValidade = 1
--SET @apres_registro = 1468200780018
--SET @apres_acondicionamento = NULL
--SET @apres_complemento = 0
--SET @apres_restricaoHospitais = 0
--SET @apres_tarja = 'Vermelha'
--SET @apres_medicamentoReferencia = 0
--SET @apres_apresentacaoFracionada = 0
--SET @apres_dataVencimentoRegistro = NULL
--SET @apres_ativa = 0
--SET @apres_inativa = 0
--SET @apres_emAnalise = 0
--SET @apres_ifaUnico = 1

INSERT INTO [carga].[EMBALAGEM_PRIMARIA] ([EMBALAGEM_PRIMARIA_TIPO],[EMBALAGEM_PRIMARIA_OBS])
   VALUES (@embp_tipo ,@embp_observacao)
   SET @embp_id = SCOPE_IDENTITY()

INSERT INTO [carga].[EMBALAGEM_SECUNDARIA]([EMBALAGEM_SECUNDARIA_TIPO],[EMBALAGEM_SECUNDARIA_OBS])
   VALUES(@embs_tipo ,@embs_observacao)
   SET @embs_id = SCOPE_IDENTITY()

----MEDICAMENTO
INSERT INTO [carga].[APRESENTACAO] ([MEDICAMENTO_ID], [EMBALAGEM_PRIMARIA_ID], [EMBALAGEM_SECUNDARIA_ID] ,[COD_APRESENTACAO],[APRESENTACAO],[NUMERO_APRESENTACAO],[TOTALIDADE_APRESENTACAO]
           ,[DATA_PUBLICACAO],[VALIDADE_PROD_MESES],[TIPO_VALIDADE],[COD_ANV_APRESENTACAO],[COMPLEMENTO_APRESENTACAO],[ACONDICIONADO],[IF_UNICO],[RESTRICAO_HOSPITAIS],[MEDICAMENTO_REFERENCIA]
           ,[APRESENTACAO_FRACIONADA],[DATA_VENCIMENTO_REGISTRO],[ATIVO],[INATIVO],[EM_ANALISE],[TARJA])
     VALUES( @med_id ,@embp_id ,@embs_id ,@apres_codigo ,@apres_apresentacao ,@apres_numero,@apres_totalidade, @apres_dataPublicacao, @apres_validade, @apres_tipoValidade, @apres_registro
            ,@apres_complemento ,@apres_acondicionamento ,@apres_ifaUnico ,@apres_restricaoHospitais ,@apres_medicamentoReferencia, @apres_apresentacaoFracionada, @apres_dataVencimentoRegistro
            ,@apres_ativa, @apres_inativa, @apres_emAnalise,@apres_tarja)

SET @apresentacao_id = SCOPE_IDENTITY()

SELECT @apresentacao_id AS APRESENTACAO_ID
RETURN;	

END
