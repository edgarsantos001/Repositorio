using Microsoft.Extensions.Logging;
using RoboTinic.Interface;
using RoboTinic.InterfaceRepositorio;
using RoboTinic.RoboDTO;
using RoboTinic.RoboUtil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RoboTinic.Service
{
    public class MaterialService : IMaterial
    {
        private int limitador = 0;
        private readonly IMaterialRepositorio _materialRepositorio;
        private readonly ILogger<MaterialService> _logger;
        const string link = "https://consultas.anvisa.gov.br/api/consulta/saude/";
        public MaterialService(ILogger<MaterialService> logger, IMaterialRepositorio materialRepositorio)
        {
            _materialRepositorio = materialRepositorio;
            _logger = logger;
        }

        public void InsertMaterial()
        {
            Material material = new Material();
            int materialId = 0;
            int qtd = 1000;
            int count = 0;
            _logger.LogTrace("Obtém Link API Consulta!!");
            Material mat = Utils.ResultRequestJson<Material>(string.Format(link + "?count={0}&filter%5BnumeroRegistro%5D=&page={1}", qtd, 1));
            _logger.LogTrace("Obtém Dados Base Material!!!");

            int totalPages = mat.totalPages;
            int totalElements = mat.totalElements;
            bool isMat = false;
            if (mat == null)
                InsertMaterial();
            else
                isMat = false;

            for (int i = 1; i <= mat.totalPages; i++)
            {
                if (isMat) {
                    material = Utils.ResultRequestJson<Material>(string.Format(link + "?count={0}&filter%5BnumeroRegistro%5D=&page={1}", qtd, i));
                    if (!material.content.Any())
                    {
                        Thread.Sleep(5000);
                        material = Utils.ResultRequestJson<Material>(string.Format(link + "?count={0}&filter%5BnumeroRegistro%5D=&page={1}", qtd, i));
                    }

                }
                else{
                    material = mat;
                    isMat = true;
                } 
                
                if (materialId == 0)
                {
                    count += material.content.Count;
                    materialId = _materialRepositorio.InsertMaterial(material);
                
                    _logger.LogTrace($"Quantidade Salva { count }");
                    _logger.LogTrace("-----------------------------------------");
                    _logger.LogTrace($"Quantidade de Itens { mat.totalElements }");
                    _logger.LogTrace("-----------------------------------------");
                    _logger.LogTrace($"Quantidade de Itens Restantes { totalElements - count }");
                    _logger.LogTrace("-----------------------------------------");
                    _logger.LogTrace($"Total de Paginas  { mat.totalPages}");
                    _logger.LogTrace("-----------------------------------------");
                    _logger.LogTrace($"Paginas Restantes  { totalPages-- }");
                }
                else
                {
                    count += material.content.Count;
                    material.content.ForEach(x => x.materialId = materialId);
                    _materialRepositorio.InsertMaterialContent(material.content);

                    _logger.LogTrace($"Quantidade Salva { count }");
                    _logger.LogTrace("-----------------------------------------");
                    _logger.LogTrace($"Quantidade de Itens { mat.totalElements }");
                    _logger.LogTrace("-----------------------------------------");
                    _logger.LogTrace($"Quantidade de Itens Restantes { totalElements - count }");
                    _logger.LogTrace("-----------------------------------------");
                    _logger.LogTrace($"Total de Paginas  { mat.totalPages}");
                    _logger.LogTrace("-----------------------------------------");
                    _logger.LogTrace($"Paginas Restantes  { totalPages-- }");
                }
            }
        }

        public void InsertDetalhes()
        {
            var sw = new Stopwatch();

            sw.Start();
            limitador++;
            _logger.LogTrace("-----------------------------------------");
            _logger.LogTrace($"Inserção dos Detalhes");

            List<string> processos = _materialRepositorio.ObterProcessos();

            if (processos.Any())
            {
                int count = processos.Count;
                foreach (var processo in processos)
                {
                    Detalhe detalhe = Utils.ResultRequestJson<Detalhe>(string.Format(link + processo));
                    _logger.LogTrace($"Processo - { processo }");
                    Content content = _materialRepositorio.ObterProcessos(processo);
                    if (detalhe != null && detalhe.registro != null)
                    {
                        content.nomeTecnico = detalhe.nomeTecnico;
                        content.cancelamento = detalhe.cancelamento;
                        content.dataCancelamento = detalhe.dataCancelamento;
                        if (detalhe.apresentacoes.Any())
                            content.apresentacoes.AddRange(detalhe.apresentacoes);

                        content.fabricantes.AddRange(detalhe.fabricantes);
                        content.risco = detalhe.risco;
                        content.vencimento = detalhe.vencimento;
                        content.publicacao = detalhe.publicacao;
                        content.apresentacaoModelo = detalhe.apresentacaoModelo;
                        content.Atualizado = true;

                    }
                    else
                    {
                        content.Erro = true;
                    }

                    _materialRepositorio.InsertOrUpdateMaterialContent(content);
                    _logger.LogTrace($"Quantidade Restante - { count-- }");

                }
                limitador = 0;
                if (_materialRepositorio.ObterProcessos().Any())
                     InsertDetalhes();

            }
            else if(limitador <= 5) {
                Thread.Sleep(5000);
                InsertDetalhes();
            }
            sw.Stop();
            _logger.LogTrace($"Tempo Execução Detalhe - { sw.Elapsed }");


        }
    }
}
