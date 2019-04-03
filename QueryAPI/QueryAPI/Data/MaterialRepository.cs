using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QueryAPI.DTO.MatDTO;
using QueryAPI.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Utils;

namespace QueryAPI.Data
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MaterialRepository> _logger;

        public MaterialRepository(IConfiguration configuration, ILogger<MaterialRepository> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void InsertFactory(Fabricantes fabricantes, int idContent)
        {
            throw new NotImplementedException();
        }

        public int InsertMaterial(MaterialDTO materialDTO)
        {
            _logger.LogInformation("Insert Material");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            int idMaterial = 0;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.InsertMaterialJson", conn);
                    //MATERIAL 
                    cmd.Parameters.Add(new SqlParameter("@mat_totaElements", materialDTO.totalElements));
                    cmd.Parameters.Add(new SqlParameter("@mat_totalpages", materialDTO.totalPages));
                    cmd.Parameters.Add(new SqlParameter("@mat_lastpage", materialDTO.last));
                    cmd.Parameters.Add(new SqlParameter("@mat_numberselements", materialDTO.numberOfElements));
                    cmd.Parameters.Add(new SqlParameter("@mat_firstpage", materialDTO.first));
                    cmd.Parameters.Add(new SqlParameter("@mat_sort", materialDTO.sort ?? 0));
                    cmd.Parameters.Add(new SqlParameter("@mat_number", materialDTO.number));
                    cmd.Parameters.Add(new SqlParameter("@mat_size", materialDTO.size));

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        idMaterial = Convert.ToInt32(reader["MATERIAL_ID"]);
                    }
                    conn.Close();
                    _logger.LogTrace("Return ID");
                }
                catch (SqlException sqlex)
                {
                  conn.Close();
                    _logger.LogError($"Insert Material{sqlex.Message}");
                }
            }
            return idMaterial;
        }

        public int InsertMaterialContent(ContentMaterialDTO contentMaterialDTO)
        {
            int idMaterial = 0;
            _logger.LogInformation("Insert Content Material");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.InsertMaterialContentJson", conn);

                    //MATERIAL 
                    cmd.Parameters.Add(new SqlParameter("@material_id", contentMaterialDTO.idMaterial));

                    //EMPRESA
                    if (contentMaterialDTO.empresa != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@emp_cnpj", contentMaterialDTO.empresa.cnpj ?? string.Empty));
                        cmd.Parameters.Add(new SqlParameter("@emp_razaoSocial", contentMaterialDTO.empresa.razaoSocial ?? string.Empty));
                        cmd.Parameters.Add(new SqlParameter("@emp_numeroAutorizacao", contentMaterialDTO.empresa.numeroAutorizacao ?? 0));
                        cmd.Parameters.Add(new SqlParameter("@emp_cnpjFormatado", contentMaterialDTO.empresa.cnpjFormatado ?? string.Empty));
                        cmd.Parameters.Add(new SqlParameter("@emp_autorizacao", contentMaterialDTO.empresa.autorizacao ?? string.Empty));
                    }

                    //VENCIMENTO
                    if (contentMaterialDTO.vencimento != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@ven_data", ConvertTypes.ConvertStringToDate(contentMaterialDTO.vencimento.data)));
                        cmd.Parameters.Add(new SqlParameter("@ven_descricao", contentMaterialDTO.vencimento.descricao ?? string.Empty));
                    }

                    //MENSAGEM
                    if (contentMaterialDTO.mensagem != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@msg_situacao", contentMaterialDTO.mensagem.situacao ?? string.Empty));
                        cmd.Parameters.Add(new SqlParameter("@msg_resolucao", contentMaterialDTO.mensagem.resolucao ?? string.Empty));
                        cmd.Parameters.Add(new SqlParameter("@msg_motivo", contentMaterialDTO.mensagem.motivo ?? string.Empty));
                        cmd.Parameters.Add(new SqlParameter("@msg_negativo", contentMaterialDTO.mensagem.negativo));
                    }
                    //CLASSE_RISCO
                    if (contentMaterialDTO.risco != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@clr_sigla", contentMaterialDTO.risco.sigla ?? string.Empty));
                        cmd.Parameters.Add(new SqlParameter("@clr_descricao", contentMaterialDTO.risco.descricao ?? string.Empty));
                    }
                    //CONTENT_MATERIAL
                    cmd.Parameters.Add(new SqlParameter("@cont_processo", contentMaterialDTO.processo ?? string.Empty));
                    cmd.Parameters.Add(new SqlParameter("@cont_descproduto", contentMaterialDTO.produto ?? string.Empty));
                    cmd.Parameters.Add(new SqlParameter("@cont_codanv", ConvertTypes.ConvertStringToLong(contentMaterialDTO.registro)));
                    cmd.Parameters.Add(new SqlParameter("@cont_situacao", contentMaterialDTO.situacao ?? string.Empty));
                    cmd.Parameters.Add(new SqlParameter("@cont_nomeTecnico", contentMaterialDTO.nomeTecnico ?? string.Empty));
                    cmd.Parameters.Add(new SqlParameter("@cont_cancelado", contentMaterialDTO.cancelado));
                    cmd.Parameters.Add(new SqlParameter("@cont_dataCancelamento", ConvertTypes.ConvertStringToDate(contentMaterialDTO.dataCancelamento)));
                    cmd.Parameters.Add(new SqlParameter("@cont_publicacao", ConvertTypes.ConvertStringToDate(contentMaterialDTO.publicacao)));
                    cmd.Parameters.Add(new SqlParameter("@cont_apresentacaoModelo", contentMaterialDTO.apresentacaoModelo));

                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        idMaterial = Convert.ToInt32(reader["CONTENT_ID"]);
                    }

                    _logger.LogInformation("Insert Content Material Sucesso");
                    conn.Close();

                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    _logger.LogError($"Insert Content Material {sqlex.Message}");
                }
            }
            return idMaterial;
        }

        public void InsertPresention(ApresentacaoMaterial presention, int idContent)
        {
            _logger.LogInformation("Insert Presention");

            _logger.LogInformation("Obtém String Connection.");
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.InsertApresentacaoJson", conn);
                    //MATERIAL 
                    cmd.Parameters.Add(new SqlParameter("@cont_content_id", idContent));
                    cmd.Parameters.Add(new SqlParameter("@ap_modelo", presention.modelo ?? string.Empty));
                    cmd.Parameters.Add(new SqlParameter("@ap_componente", presention.componente ?? string.Empty));
                    cmd.Parameters.Add(new SqlParameter("@ap_apresentacao", presention.apresentacao ?? string.Empty));

                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                }
                catch (SqlException sqlex)
                {
                    conn.Close();
                    throw sqlex;
                }
            }
        }
    }
}
