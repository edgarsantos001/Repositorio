using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QueryAPI.DTO.MatDTO;
using QueryAPI.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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
            string connstr = _configuration.GetSection("Connection:ConnectionString").Value;
            throw new NotImplementedException();
        }

        public int InsertMaterialContent(ContentMaterialDTO contentMaterialDTO)
        {
            throw new NotImplementedException();
        }

        public void InsertPresention(ApresentacaoMaterial presention, int idContent)
        {
            _logger.LogInformation("Insert Presention");
            string connstr = _configuration.GetConnectionString("ConnectionString");
                //"Data Source=.\\SQLEXPRESS;Initial Catalog=SUPORTE;Integrated Security=True;Connect Timeout=90;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
