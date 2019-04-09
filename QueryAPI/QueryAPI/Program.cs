using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using QueryAPI.Interface;
using QueryAPI.Service;
using QueryAPI.Data;

namespace QueryAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, args);
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<App>().Run();

            // AtualizarMaterial();
            // AtualizaMedicamento();
            Console.ReadLine();
        }


        private static void ConfigureServices(IServiceCollection serviceCollection, string[] args)
        {
            string EnvName = "Production";
            foreach (DictionaryEntry env in System.Environment.GetEnvironmentVariables())
                if (env.Key.ToString().ToUpper() == "ASPNETCORE_ENVIRONMENT")
                {
                    EnvName = env.Value.ToString();
                    break;
                }

            var configuration = new ConfigurationBuilder()
                  .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                  .AddJsonFile($"appsettings.{EnvName}.json", false, true).Build();

            serviceCollection.AddLogging(logginBuilder =>
            {
                logginBuilder.AddConfiguration(configuration.GetSection("Logging"));
                logginBuilder.AddConsole();
                logginBuilder.AddSerilog();
                logginBuilder.AddDebug();
            });

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo.RollingFile(configuration["Serilog:LogFile"])
                .CreateLogger();

            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddSingleton<IConfiguration>(configuration);

            serviceCollection.AddTransient<IRepository, RepositoryService>();
            serviceCollection.AddTransient<IMaterial, MaterialService>();
            serviceCollection.AddTransient<IMaterialRepository, MaterialRepository>();


            serviceCollection.AddTransient<IMedicamento, MedicamentoService>();
            serviceCollection.AddTransient<IMedicamentoRepository, MedicamentoRepository>();



            //public static void AtualizarMaterial()
            //{
            //    string link = "https://consultas.anvisa.gov.br/api/consulta/saude/"; 

            //    MaterialDTO material = ResultRequest<MaterialDTO>(string.Format(link + "?count={0}&filter%5BnumeroRegistro%5D=&page={1}", 50, 1));
            //    int qtdPages = material.totalPages;
            //    int idmaterial = InsertMaterial(material) ;
            //    for (int i = 1; i < qtdPages; i++)
            //    {
            //        try
            //        {
            //            if (material.content == null)
            //                material = ResultRequest<MaterialDTO>(string.Format(link + "?count={0}&filter%5BnumeroRegistro%5D=&page={1}", 50, i));
            //            int count = 1;

            //            foreach (var mat in material.content)
            //            {
            //                ContentMaterialDTO content = ResultRequest<ContentMaterialDTO>(link + mat.processo);
            //                if (content.processo != null)
            //                {
            //                    content.situacao = mat.situacao;
            //                    content.idMaterial = idmaterial;
            //                    int idContent = InsertMaterialContent(content);
            //                    if (idContent != 0)
            //                    {
            //                        Fabricante(content.fabricantes, idContent);
            //                        Apresentacao(content.apresentacoes, idContent);
            //                        Console.WriteLine($"SUCESSO: \n {mat.processo}");
            //                    }
            //                    else
            //                    {
            //                        Console.WriteLine($"EXISTE: \n {mat.processo}");
            //                        Console.WriteLine($"QTD: \n {count++}");   
            //                    }
            //                }
            //            }
            //            material = new MaterialDTO();
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine($"Error: \n {ex.Message} \n Page : {i}");
            //            material = new MaterialDTO();
            //        }

            //    }
            //}

            //public static void AtualizaMedicamento()
            //{
            //    //?count=10&filter%5Btarjas%5D=1,2,3,4&page=419
            //    //https://consultas.anvisa.gov.br/api/consulta/medicamento/produtos/?count=10&filter%5BcategoriasRegulatorias%5D=1,2,3,4,5,6,7,8&page=1
            //    string link = "https://consultas.anvisa.gov.br/api/consulta/medicamento/produtos/";
            //    //"?count=10&filter%5Btarjas%5D=1,2,3,4&page={0}";
            //    int pagesCount = 419;

            //    for (int i = 1; i < pagesCount; i++)
            //    {
            //        MedicamentoDTO medicamento = ResultRequest<MedicamentoDTO>(string.Format(link + "?count=10&filter%5Btarjas%5D=1,2,3,4&page={0}", i));

            //        foreach (ContentMedicamentoDTO med in medicamento.content)
            //        {
            //            DetalhesDTO detalhe = ResultRequest<DetalhesDTO>(link + med.processo.numero);
            //            detalhe.processo = med.processo;


            //        }
            //    }













            //}

            //private static void Apresentacao(List<ApresentacaoMaterial> apresentacoes, int idContent)
            //{
            //    foreach (var apresentacao in apresentacoes)
            //    {
            //        InsertApresentacao(apresentacao, idContent);                
            //    }
            //}

            //private static void Fabricante(List<Fabricantes> fabricantes, int idContent)
            //{
            //    foreach (var fabricante in fabricantes)
            //    {
            //        InsertFabricante(fabricante, idContent);
            //    }
            //}

            //private static void InsertApresentacao(ApresentacaoMaterial ap, int idContent)
            //{
            //    string connstr = "Data Source=.\\SQLEXPRESS;Initial Catalog=SUPORTE;Integrated Security=True;Connect Timeout=90;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //    using (SqlConnection conn = new SqlConnection(connstr))
            //    {
            //        try
            //        {                   
            //            SqlCommand cmd = new SqlCommand("dbo.InsertApresentacaoJson", conn);
            //            //MATERIAL 
            //            cmd.Parameters.Add(new SqlParameter("@cont_content_id", idContent));
            //            cmd.Parameters.Add(new SqlParameter("@ap_modelo", ap.modelo ?? string.Empty));
            //            cmd.Parameters.Add(new SqlParameter("@ap_componente", ap.componente ?? string.Empty));
            //            cmd.Parameters.Add(new SqlParameter("@ap_apresentacao", ap.apresentacao ?? string.Empty));

            //            cmd.CommandType = CommandType.StoredProcedure;
            //            conn.Open();
            //            SqlDataReader reader = cmd.ExecuteReader();
            //            conn.Close();
            //        }
            //        catch (SqlException sqlex)
            //        {
            //            conn.Close();
            //            throw sqlex;
            //        }
            //    }
            //}

            //private static void InsertFabricante(Fabricantes fab, int idContent)
            //{
            //    string connstr = "Data Source=.\\SQLEXPRESS;Initial Catalog=SUPORTE;Integrated Security=True;Connect Timeout=90;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //    using (SqlConnection conn = new SqlConnection(connstr))
            //    {
            //        try
            //        {
            //            SqlCommand cmd = new SqlCommand("dbo.InsertFabricanteJson", conn);
            //            //MATERIAL 
            //            cmd.Parameters.Add(new SqlParameter("@cont_content_id",idContent ));
            //            cmd.Parameters.Add(new SqlParameter("@fab_atividade", fab.atividade ?? string.Empty));
            //            cmd.Parameters.Add(new SqlParameter("@fab_razaosocial", fab.razaoSocial ?? string.Empty));
            //            cmd.Parameters.Add(new SqlParameter("@fab_pais", fab.pais ?? string.Empty));
            //            cmd.Parameters.Add(new SqlParameter("@fab_local ", fab.local ?? string.Empty));

            //            cmd.CommandType = CommandType.StoredProcedure;
            //            conn.Open();
            //            SqlDataReader reader = cmd.ExecuteReader();
            //            conn.Close();
            //        }
            //        catch (SqlException sqlex)
            //        {
            //            conn.Close();
            //            throw sqlex;
            //        }
            //    }
            //}

            //public static void ObterListaAtualizadoAns()
            //{

            //    string connstr = "";
            //    SqlDataReader reader;
            //    using (SqlConnection conn = new SqlConnection(connstr))
            //    {
            //        SqlCommand cmd = new SqlCommand("carga.ObterListAnsSistap", conn);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        conn.Open();

            //        reader = cmd.ExecuteReader();
            //        while (reader.Read())
            //        {

            //        }
            //        conn.Close();
            //    }   
            //}

            //public static int InsertMaterialContent(ContentMaterialDTO dto)
            //{
            //    int idMaterial = 0;
            //    string connstr = "Data Source=.\\SQLEXPRESS;Initial Catalog=SUPORTE;Integrated Security=True;Connect Timeout=90;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //    using (SqlConnection conn = new SqlConnection(connstr))
            //    {
            //        try
            //        {
            //            SqlCommand cmd = new SqlCommand("dbo.InsertMaterialContentJson", conn);

            //            //MATERIAL 
            //            cmd.Parameters.Add(new SqlParameter("@material_id", dto.idMaterial));

            //            //EMPRESA
            //            if (dto.empresa != null)
            //            {
            //                cmd.Parameters.Add(new SqlParameter("@emp_cnpj", dto.empresa.cnpj ?? string.Empty));
            //                cmd.Parameters.Add(new SqlParameter("@emp_razaoSocial", dto.empresa.razaoSocial ?? string.Empty));
            //                cmd.Parameters.Add(new SqlParameter("@emp_numeroAutorizacao", dto.empresa.numeroAutorizacao ?? 0));
            //                cmd.Parameters.Add(new SqlParameter("@emp_cnpjFormatado", dto.empresa.cnpjFormatado ?? string.Empty));
            //                cmd.Parameters.Add(new SqlParameter("@emp_autorizacao", dto.empresa.autorizacao ?? string.Empty));
            //            }

            //            //VENCIMENTO
            //            if (dto.vencimento != null)
            //            {
            //                cmd.Parameters.Add(new SqlParameter("@ven_data", ConvertTypes.ConvertStringToDate(dto.vencimento.data)));
            //                cmd.Parameters.Add(new SqlParameter("@ven_descricao", dto.vencimento.descricao ?? string.Empty));
            //            }

            //            //MENSAGEM
            //            if (dto.mensagem != null)
            //            {
            //                cmd.Parameters.Add(new SqlParameter("@msg_situacao", dto.mensagem.situacao ?? string.Empty));
            //                cmd.Parameters.Add(new SqlParameter("@msg_resolucao", dto.mensagem.resolucao ?? string.Empty));
            //                cmd.Parameters.Add(new SqlParameter("@msg_motivo", dto.mensagem.motivo ?? string.Empty));
            //                cmd.Parameters.Add(new SqlParameter("@msg_negativo", dto.mensagem.negativo));
            //            }
            //            //CLASSE_RISCO
            //            if (dto.risco != null)
            //            {
            //                cmd.Parameters.Add(new SqlParameter("@clr_sigla", dto.risco.sigla ?? string.Empty));
            //                cmd.Parameters.Add(new SqlParameter("@clr_descricao", dto.risco.descricao ?? string.Empty));
            //            }
            //            //CONTENT_MATERIAL
            //             cmd.Parameters.Add(new SqlParameter("@cont_processo", dto.processo ?? string.Empty));
            //             cmd.Parameters.Add(new SqlParameter("@cont_descproduto", dto.produto ?? string.Empty));
            //             cmd.Parameters.Add(new SqlParameter("@cont_codanv", ConvertTypes.ConvertStringToLong(dto.registro)));
            //             cmd.Parameters.Add(new SqlParameter("@cont_situacao", dto.situacao ?? string.Empty));
            //             cmd.Parameters.Add(new SqlParameter("@cont_nomeTecnico", dto.nomeTecnico ?? string.Empty));
            //             cmd.Parameters.Add(new SqlParameter("@cont_cancelado", dto.cancelado));
            //             cmd.Parameters.Add(new SqlParameter("@cont_dataCancelamento",ConvertTypes.ConvertStringToDate(dto.dataCancelamento)));
            //             cmd.Parameters.Add(new SqlParameter("@cont_publicacao", ConvertTypes.ConvertStringToDate(dto.publicacao)));
            //             cmd.Parameters.Add(new SqlParameter("@cont_apresentacaoModelo", dto.apresentacaoModelo));

            //            cmd.CommandType = CommandType.StoredProcedure;
            //            conn.Open();
            //            SqlDataReader reader = cmd.ExecuteReader();

            //            while (reader.Read())
            //            {
            //                idMaterial = Convert.ToInt32(reader["CONTENT_ID"]);
            //            }

            //            conn.Close();

            //        }
            //        catch (SqlException sqlex)
            //        {
            //            conn.Close();
            //            throw sqlex; 
            //        }
            //    }
            //    return idMaterial;
            //}

            //public static int InsertMaterial(MaterialDTO dto)
            //{
            //    int idMaterial = 0;
            //    string connstr = "Data Source=.\\SQLEXPRESS;Initial Catalog=SUPORTE;Integrated Security=True;Connect Timeout=90;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //    using (SqlConnection conn = new SqlConnection(connstr))
            //    {
            //        try
            //        {
            //            conn.Open();
            //            SqlCommand cmd = new SqlCommand("dbo.InsertMaterialJson", conn);

            //            //MATERIAL 
            //            cmd.Parameters.Add(new SqlParameter("@mat_totaElements", dto.totalElements));
            //            cmd.Parameters.Add(new SqlParameter("@mat_totalpages", dto.totalPages));
            //            cmd.Parameters.Add(new SqlParameter("@mat_lastpage", dto.last));
            //            cmd.Parameters.Add(new SqlParameter("@mat_numberselements", dto.numberOfElements));
            //            cmd.Parameters.Add(new SqlParameter("@mat_firstpage", dto.first));
            //            cmd.Parameters.Add(new SqlParameter("@mat_sort", dto.sort ?? 0));
            //            cmd.Parameters.Add(new SqlParameter("@mat_number", dto.number));
            //            cmd.Parameters.Add(new SqlParameter("@mat_size", dto.size));

            //            cmd.CommandType = CommandType.StoredProcedure;

            //            SqlDataReader reader = cmd.ExecuteReader();

            //            while (reader.Read())
            //            {
            //                idMaterial = Convert.ToInt32(reader["MATERIAL_ID"]);
            //            }
            //            conn.Close();
            //        }
            //        catch (SqlException sqlex)
            //        {
            //            conn.Close();
            //            throw sqlex;
            //        }
            //    }
            //    return idMaterial;
            //}

        }
    }
}

//TODO: Separar os itens por parametros 

// string urlmedicamento = "https://consultas.anvisa.gov.br/api/consulta/medicamento/produtos/
//?count=10&
//filter %5BnumeroRegistro%5D=178170007
//&page=1";

//principal princ = ResultRequest<principal>(urlmedicamento);

//string urlMedicamentoDetalhe = "https://consultas.anvisa.gov.br/api/consulta/medicamento/produtos/" + princ.content[0].processo.numero;

//DetalhesDTO detalhes = ResultRequest<DetalhesDTO>(urlMedicamentoDetalhe);

//string urlmaterial = "https://consultas.anvisa.gov.br/api/consulta/saude/?count=100&filter%5BnumeroRegistro%5D=80522420005&page={0}";

//bool valido = true;
//int count = 1;
//while (valido)
//{
//    MaterialDTO material = ResultRequest<MaterialDTO>(String.Format(urlmaterial, count));
//    if (material.content.Any())
//    {
//        count++;
//    }
//    else
//    {
//        valido = false;
//    }
//}
// string urlMaterialDetalhes = "https://consultas.anvisa.gov.br/api/consulta/saude/";
//MaterialDetalheDTO materialDetalhe = ResultRequest<MaterialDetalheDTO>(urlMaterialDetalhes + material.content[0].processo);
//var resquest1 = string.Empty;
//DetalhesDTO detalhes = ResultRequest<DetalhesDTO>("https://consultas.anvisa.gov.br/api/consulta/medicamento/produtos/"+principal.content[0].processo.numero);

//request.Method = "GET";
//request.Headers.Add("Authorization", "Guest");

//using (var response = request.GetResponse())
//{
//    var stream = response.GetResponseStream();
//    using (StreamReader reader = new StreamReader(stream))
//    {
//        object objResponse = reader.ReadToEnd();
//        principal prin = JsonConvert.DeserializeObject<principal>(objResponse.ToString());
//        //var teste = principal; 
//        //Console.WriteLine(post.content + " " + post.title + " " + post.body);

//        string numeroProcesso = prin.content[0].processo.numero;

//        Console.ReadLine();
//      //streamDados.Close();
//    }  
//}

//https://consultas.anvisa.gov.br/api/consulta/medicamento/produtos/25351637563200922
