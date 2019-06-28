using Microsoft.Extensions.Logging;
using QueryAPI.DTO.MatDTO;
using QueryAPI.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryAPI.Service
{
    public class MaterialService : IMaterial
    {
        private readonly IMaterialRepository _materialRepository; 
        private readonly ILogger<MaterialService> _logger;

        public MaterialService(ILogger<MaterialService> logger, IMaterialRepository materialRepository)
        {
            _logger = logger;
            _materialRepository = materialRepository;
        }
        
        public void InsertMaterial()
        {
            _logger.LogTrace("Obtém Link API Consulta!!"); 
            string link = "https://consultas.anvisa.gov.br/api/consulta/saude/";

            _logger.LogTrace("Obtém Dados Base Material!!!");

            MaterialDTO material = Utils.ResultRequestJson<MaterialDTO>(string.Format(link + "?count={0}&filter%5BnumeroRegistro%5D=&page={1}", 2000, 1));

            int qtdPages = material.totalPages;
            _logger.LogTrace($"Calculo de Quantidade de Paginas para consulta. \n Paginas : {qtdPages}");

            _logger.LogTrace("Inserir os primeiros dados na tabela Material.");

            int idmaterial = _materialRepository.InsertMaterial(material) ;
            _logger.LogTrace("Retora Id Material para ser inserido nas Tabelas Filhas.");

            _logger.LogTrace("Inicia o FOR com a quantidade de Paginas para carregar as tabelas.");
            int count = 1;
            for (int i = 62; i < qtdPages; i++)
            {
                try
                {
                    _logger.LogTrace("Verifica se o Content Carregado no OBJ pelo Json está nulo.");
                    if (material.content == null)
                    {
                        _logger.LogTrace($"Otendo Itens para Inclusão: \n Paginas Restantes {qtdPages - i}");
                        material = Utils.ResultRequestJson<MaterialDTO>(string.Format(link + "?count={0}&filter%5BnumeroRegistro%5D=&page={1}", 2000, i));
                        Console.Beep();
                    }


                    _logger.LogTrace("o Content não estando nulo entra em um Forech para Inserção dos dados.");
                    foreach (var mat in material.content)
                    {
                        _logger.LogTrace("Obtém os Detalhes do produto"); //Pelo numero do processo
                        ContentMaterialDTO content = Utils.ResultRequestJson<ContentMaterialDTO>(link + mat.processo);
                        if (content.processo != null)
                        {
                            content.situacao = mat.situacao;
                            content.idMaterial = idmaterial;

                            _logger.LogTrace("Inseri os Detalhes Da Tabela Pai Retornando o ID");
                            int idContent = _materialRepository.InsertMaterialContent(content);

                            _logger.LogTrace("Verifica se o Id não é 0.");
                            if (idContent != 0)
                            {
                                _logger.LogTrace("Inseri Fabricantes ");
                                InsertFactory(content.fabricantes, idContent);
                                _logger.LogTrace("Inseri Apresentação do Produto.");
                                InsertPresentetion(content.apresentacoes, idContent);
                                Console.WriteLine($"SUCESSO: \n {mat.processo}");
                            }
                            else
                            {
                                _logger.LogTrace("Quando o Id retorna 0 significa que o produto já existe na base de dados.");
                                Console.WriteLine($"EXISTE: \n {mat.processo}");
                                Console.WriteLine($"QTD: \n {count++}");   
                            }
                        }
                    }
                    material = new MaterialDTO();
                }
                catch (Exception ex)
                {
                    _logger.LogError("Caso ocorra uma Exceção é apresentado uma mensagem de ERRO no Console mas o processo continua.");
                    Console.WriteLine($"Error: \n {ex.Message} \n Page : {i}");
                    material = new MaterialDTO();
                }
            }
        }

        public void InsertPresentetion(List<ApresentacaoMaterial> presentetions, int idContent)
        {
            foreach (var presentetion in presentetions)
            {
                _materialRepository.InsertPresention(presentetion, idContent);
            }
        }

        public void InsertFactory(List<Fabricantes> fabricantes, int idContent)
        {
            foreach (var fabricante in fabricantes)
            {
              _materialRepository.InsertFactory(fabricante, idContent);
            }
        }
    }
}
