using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QueryAPI.DTO;
using QueryAPI.DTO.MedDTO;
using QueryAPI.Interface;
using System;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace QueryAPI.Data
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        private readonly ILogger<MedicamentoRepository> _logger;
        private readonly IConfiguration _configuration; 

        public MedicamentoRepository(ILogger<MedicamentoRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        
        public void InsertRotulos(string desc, int idMedDetalhe)
        {
            _logger.LogInformation("Insert Rotulo.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("carga.InsertRotuloJson", conn);
             
                    cmd.Parameters.Add(new SqlParameter("@rotulo_desc", desc.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@idmedDet_id", idMedDetalhe));
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    _logger.LogTrace("Sucesso!");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Detalhe Medicamento: \n {sqlex.Message}");
                }
            }

        }

        public void InsertClasseTerapeutica(string desc, int idMedDetalhe)
        {
            _logger.LogInformation("Insert ClasseTerapeutica.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("carga.InsertClasseTerapeuticaJson", conn);
                    cmd.Parameters.Add(new SqlParameter("@classe_terapeutica_desc", desc.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@idmedDet_id", idMedDetalhe));
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();

                    _logger.LogTrace("Sucesso!");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Classe Teraputica Medicamento: \n {sqlex.Message}");
                }
            }
        }
                
        public int InsertDetalheMedicamento(DetalhesDTO detalheDTO)
        {
            _logger.LogInformation("Insert Detalhe Medicamento.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            int idMedicamento = 0;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.InsertMedicamentoJson", conn);
                    //EMPRESA
                    cmd.Parameters.Add(new SqlParameter("@emp_cnpj", detalheDTO.empresa.cnpj));
                    cmd.Parameters.Add(new SqlParameter("@emp_razaoSocial", detalheDTO.empresa.razaoSocial));
                    cmd.Parameters.Add(new SqlParameter("@emp_numeroAutorizacao", detalheDTO.empresa.numeroAutorizacao ?? 0));
                    cmd.Parameters.Add(new SqlParameter("@emp_cnpjFormatado", detalheDTO.empresa.cnpjFormatado));
                    cmd.Parameters.Add(new SqlParameter("@emp_autorizacao", detalheDTO.empresa.autorizacao));

                    //PROCESSO
                    cmd.Parameters.Add(new SqlParameter("@proc_numero_processo", ConvertTypes.ConvertStringToLong(detalheDTO.processo.numero)));
                    cmd.Parameters.Add(new SqlParameter("@proc_situacao", detalheDTO.processo.situacao ?? 0));
                    cmd.Parameters.Add(new SqlParameter("@proc_processo_formatado", detalheDTO.processo.numeroProcessoFormatado));

                    //MEDICAMENTO
                    cmd.Parameters.Add(new SqlParameter("@med_codigo_prod", detalheDTO.codigoProduto));
                    cmd.Parameters.Add(new SqlParameter("@med_tipo_prod", detalheDTO.tipoProduto));

                    DateTime dateTime = ConvertTypes.ConvertStringToDate(detalheDTO.dataProduto);
                    if (dateTime.Year > 1900)
                        cmd.Parameters.Add(new SqlParameter("@med_data_prod", dateTime));
                    else
                        cmd.Parameters.Add(new SqlParameter("@med_data_prod", DateTime.Now));

                    cmd.Parameters.Add(new SqlParameter("@med_nome_comercial", detalheDTO.nomeComercial));
                    cmd.Parameters.Add(new SqlParameter("@med_cod_anvisa_med", ConvertTypes.ConvertStringToLong(detalheDTO.numeroRegistro)));
                    cmd.Parameters.Add(new SqlParameter("@med_data_vencimento", detalheDTO.dataVencimento));
                    cmd.Parameters.Add(new SqlParameter("@med_mes_ano_vencimento", detalheDTO.mesAnoVencimento));
                    cmd.Parameters.Add(new SqlParameter("@med_cod_parecer_publico", detalheDTO.codigoParecerPublico));
                    cmd.Parameters.Add(new SqlParameter("@med_cod_bula_pacientes", detalheDTO.codigoBulaPaciente));
                    cmd.Parameters.Add(new SqlParameter("@med_cod_bula_profissional", detalheDTO.codigoBulaProfissional));
                    cmd.Parameters.Add(new SqlParameter("@med_data_vencimento_registro", ConvertTypes.ConvertStringToDate(detalheDTO.dataVencimentoRegistro)));
                    if (detalheDTO.principioAtivo != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@med_principio_ativo", detalheDTO.principioAtivo.ToUpper()));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@med_principio_ativo", string.Empty));
                    }

                    cmd.Parameters.Add(new SqlParameter("@med_medicamento_referencia", detalheDTO.medicamentoReferencia));
                    cmd.Parameters.Add(new SqlParameter("@med_categoria_regulatoria", detalheDTO.categoriaRegulatoria));
                    cmd.Parameters.Add(new SqlParameter("@med_atc", detalheDTO.atc));

                                                                                                                                    
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        idMedicamento = Convert.ToInt32(reader["MEDICAMENTO_ID"]);
                    }
                    conn.Close();
                    _logger.LogTrace("Return ID");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Detalhe Medicamento: \n {sqlex.Message}");
                }
            }
            return idMedicamento;

        }

        public int InsertMedicamento(DetalhesDTO detalheMedicamentoDTO)
        {
            throw new System.NotImplementedException();
        }

        public int InsertMedicamentoContent(ContentMedicamentoDTO contentMaterialDTO)
        {
            throw new System.NotImplementedException();
        }

        public int InsertApresentacao(ApresentacaoDTO dto, int idMedDet)
        {
            _logger.LogInformation("Insert Apresentacao Medicamento.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            int apresentacaoId = 0;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("carga.InsertApresentacaoMedicamentoJson", conn);

                    cmd.Parameters.Add(new SqlParameter("@med_id", idMedDet));

                    //EMBALAGEM PRIMARIA

                    if (dto.embalagemPrimaria != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@embp_tipo", dto.embalagemPrimaria.tipo));
                        cmd.Parameters.Add(new SqlParameter("@embp_observacao", dto.embalagemPrimaria.observacao ?? string.Empty));

                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@embp_tipo", string.Empty));
                        cmd.Parameters.Add(new SqlParameter("@embp_observacao", string.Empty));
                    }

                    if (dto.embalagemSecundaria != null)
                    {
                        //EMBALAGEM SECUNDARIA
                        cmd.Parameters.Add(new SqlParameter("@embs_tipo", dto.embalagemSecundaria.tipo));
                        cmd.Parameters.Add(new SqlParameter("@embs_observacao", dto.embalagemSecundaria.observacao ?? string.Empty));
                    }
                    else
                    {
                        //EMBALAGEM SECUNDARIA
                        cmd.Parameters.Add(new SqlParameter("@embs_tipo", string.Empty));
                        cmd.Parameters.Add(new SqlParameter("@embs_observacao", string.Empty));
                    }


                    //PROCESSO
                    cmd.Parameters.Add(new SqlParameter("@apres_codigo", dto.codigo));//int
                    cmd.Parameters.Add(new SqlParameter("@apres_numero", dto.numero ?? 0));
                    cmd.Parameters.Add(new SqlParameter("@apres_totalidade", dto.totalidade ?? 0));
                    cmd.Parameters.Add(new SqlParameter("@apres_apresentacao", dto.apresentacao));

                    DateTime dateTime = ConvertTypes.ConvertStringToDate(dto.dataPublicacao);
                    if (dateTime.Year > 1900)
                        cmd.Parameters.Add(new SqlParameter("@apres_dataPublicacao", dateTime));
                    else
                        cmd.Parameters.Add(new SqlParameter("@apres_dataPublicacao", DateTime.Now));



                    cmd.Parameters.Add(new SqlParameter("@apres_validade", dto.validade));

                    cmd.Parameters.Add(new SqlParameter("@apres_tipoValidade", dto.tipoValidade));
                    cmd.Parameters.Add(new SqlParameter("@apres_registro", ConvertTypes.ConvertStringToLong(dto.registro)));
                    cmd.Parameters.Add(new SqlParameter("@apres_acondicionamento", dto.acondicionamento ?? string.Empty));
                    cmd.Parameters.Add(new SqlParameter("@apres_complemento", dto.complemento ?? string.Empty));
                    cmd.Parameters.Add(new SqlParameter("@apres_restricaoHospitais", ConvertTypes.ConvertStringToBool(dto.restricaoHospitais)));
                    cmd.Parameters.Add(new SqlParameter("@apres_tarja", dto.tarja));

                    cmd.Parameters.Add(new SqlParameter("@apres_medicamentoReferencia", ConvertTypes.ConvertStringToBool(dto.medicamentoReferencia)));
                    cmd.Parameters.Add(new SqlParameter("@apres_apresentacaoFracionada", ConvertTypes.ConvertStringToBool(dto.apresentacaoFracionada)));
                    cmd.Parameters.Add(new SqlParameter("@apres_dataVencimentoRegistro", ConvertTypes.ConvertStringToDate(dto.dataVencimentoRegistro)));

                    cmd.Parameters.Add(new SqlParameter("@apres_ativa", dto.ativa));
                    cmd.Parameters.Add(new SqlParameter("@apres_inativa", dto.inativa));
                    cmd.Parameters.Add(new SqlParameter("@apres_emAnalise", dto.emAnalise));
                    cmd.Parameters.Add(new SqlParameter("@apres_ifaUnico ", dto.ifaUnico));


                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        apresentacaoId = Convert.ToInt32(reader["APRESENTACAO_ID"]);
                    }
                    conn.Close();
                    _logger.LogTrace("Return ID");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Detalhe Medicamento: \n {sqlex.Message}");
                }
            }
            return apresentacaoId;

        }

        public void InsertFactory(FabricanteDTO fabricante, int idMedicamento, char tipo)
        {
            _logger.LogInformation("Insert Fabricante.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("carga.InsertFabricanteMedicamentoJson", conn);

                    cmd.Parameters.Add(new SqlParameter("@apresentacao_id", idMedicamento));

                    cmd.Parameters.Add(new SqlParameter("@fab_razaosocial", fabricante.RAZAO_SOCIAL));
                    cmd.Parameters.Add(new SqlParameter("@fab_endereco", fabricante.ENDERECO));
                    cmd.Parameters.Add(new SqlParameter("@fab_pais", fabricante.PAIS));
                    cmd.Parameters.Add(new SqlParameter("@fab_cnpj", fabricante.CNPJ));
                    cmd.Parameters.Add(new SqlParameter("@fab_cidade", fabricante.CIDADE));
                    cmd.Parameters.Add(new SqlParameter("@fab_uf", fabricante.UF));
                    cmd.Parameters.Add(new SqlParameter("@fab_tipo", tipo));

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    _logger.LogTrace("Sucesso!");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Detalhe Medicamento: \n {sqlex.Message}");
                }
            }

        }

        public void InsertFormasFarmaceuticas(string formasFarmaceuticas, int idMedDet)
        {
            _logger.LogInformation("Insert Formas Farmaceuticas.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("carga.InsertFormasFarmaceuticasJson", conn);

                    cmd.Parameters.Add(new SqlParameter("@formas_desc", formasFarmaceuticas.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@apresentacao_id", idMedDet));
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    _logger.LogTrace("Sucesso!");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Detalhe Medicamento: \n {sqlex.Message}");
                }
            }

        }

        public void InsertDestinacao(string destinacao, int idMedDet)
        {
            _logger.LogInformation("Insert Destinação.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("carga.InsertDestinacaoJson", conn);

                    cmd.Parameters.Add(new SqlParameter("@destinacao_desc", destinacao.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@apresentacao_id", idMedDet));
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    _logger.LogTrace("Sucesso!");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Detalhe Medicamento: \n {sqlex.Message}");
                }
            }
        }

        public void InsertRestricaoUso(string restricaoUso, int idMedDet)
        {
            _logger.LogInformation("Insert Restricao De Uso.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("carga.InsertRestriacaoUsoJson", conn);

                    cmd.Parameters.Add(new SqlParameter("@restricaoUso_desc", restricaoUso.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@apresentacao_id", idMedDet));
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    _logger.LogTrace("Sucesso!");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Detalhe Medicamento: \n {sqlex.Message}");
                }
            }
        }

        public void InsertRestricaoPrescricao(string restricaoPrescricao, int idMedDet)
        {
            _logger.LogInformation("Insert Restricao Prescrição.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("carga.InsertRestriacaoPrescricaoJson", conn);

                    cmd.Parameters.Add(new SqlParameter("@restricao_desc", restricaoPrescricao.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@apresentacao_id", idMedDet));
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    _logger.LogTrace("Sucesso!");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Detalhe Medicamento: \n {sqlex.Message}");
                }
            }
        }

        public void InsertConservacao(string conservacao, int idMedDet)
        {
            _logger.LogInformation("Insert Conservacao.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("carga.InsertConservacaoJson", conn);

                    cmd.Parameters.Add(new SqlParameter("@conservacao_desc", conservacao.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@apresentacao_id", idMedDet));
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    _logger.LogTrace("Sucesso!");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Detalhe Medicamento: \n {sqlex.Message}");
                }
            }
        }

        public void InsertPrincipioAtivo(string principiosAtivos, int idMedDet)
        {
             _logger.LogInformation("Insert Principio Ativo.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("carga.InsertPrincipioAtivoJson", conn);

                    cmd.Parameters.Add(new SqlParameter("@principio_ativo_desc", principiosAtivos.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@apresentacao_id", idMedDet));
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    _logger.LogTrace("Sucesso!");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Detalhe Medicamento: \n {sqlex.Message}");
                }
            }
        }

        public void InsertViasAdministracao(string viasAdministracao, int idMedDet)
        {
            _logger.LogInformation("Insert Adminstração.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("carga.InsertAdministracaoJson", conn);

                    cmd.Parameters.Add(new SqlParameter("@administracao_desc", viasAdministracao.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@apresentacao_id", idMedDet));
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    _logger.LogTrace("Sucesso!");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Detalhe Medicamento: \n {sqlex.Message}");
                }
            }
        }

        public void InsertMarcas(string marca, int idMedDet)
        {
            _logger.LogInformation("Insert Marcas.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("carga.InsertMarcaJson", conn);

                    cmd.Parameters.Add(new SqlParameter("@marca_desc", marca.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@apresentacao_id", idMedDet));
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    _logger.LogTrace("Sucesso!");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Detalhe Medicamento: \n {sqlex.Message}");
                }
            }

        }

        public void InsertAcessorios(Acessorio acessorio, int idMedDet)
        {
            _logger.LogInformation("Insert Restricao De Uso.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("carga.InsertAcessoriosJson", conn);

                    cmd.Parameters.Add(new SqlParameter("@acessorios_desc", acessorio.descricao.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@acessorios_qtd", acessorio.quantidade));
                    cmd.Parameters.Add(new SqlParameter("@apresentacao_id", idMedDet));
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    _logger.LogTrace("Sucesso!");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Detalhe Medicamento: \n {sqlex.Message}");
                }
            }
        }

        public void InsertEnvoltorio(string envoltorio, int idMedDet)
        {
            _logger.LogInformation("Insert Envoltorios.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("carga.InsertEnvoltorioJson", conn);
                    cmd.Parameters.Add(new SqlParameter("@env_envoltorios_desc", envoltorio.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@apresentacao_id", idMedDet));
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    _logger.LogTrace("Sucesso!");
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert ERRO Detalhe Medicamento: \n {sqlex.Message}");
                }
            }
        }
    }
}
