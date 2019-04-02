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
        
        public void AtualizarMaterial()
        {
            string link = "https://consultas.anvisa.gov.br/api/consulta/saude/"; 

            MaterialDTO material = Utils.ResultRequestJson<MaterialDTO>(string.Format(link + "?count={0}&filter%5BnumeroRegistro%5D=&page={1}", 50, 1));
            int qtdPages = material.totalPages;
            int idmaterial = _materialRepository.InsertMaterial(material) ;

            for (int i = 1; i < qtdPages; i++)
            {
                try
                {
                    if (material.content == null)
                        material = Utils.ResultRequestJson<MaterialDTO>(string.Format(link + "?count={0}&filter%5BnumeroRegistro%5D=&page={1}", 50, i));
                    int count = 1;
                    foreach (var mat in material.content)
                    {
                        ContentMaterialDTO content = Utils.ResultRequestJson<ContentMaterialDTO>(link + mat.processo);
                        if (content.processo != null)
                        {
                            content.situacao = mat.situacao;
                            content.idMaterial = idmaterial;
                            int idContent = _materialRepository.InsertMaterialContent(content);
                            if (idContent != 0)
                            {
                                InsertFactory(content.fabricantes, idContent);
                                InsertPresentetion(content.apresentacoes, idContent);
                                Console.WriteLine($"SUCESSO: \n {mat.processo}");
                            }
                            else
                            {
                                Console.WriteLine($"EXISTE: \n {mat.processo}");
                                Console.WriteLine($"QTD: \n {count++}");   
                            }
                        }
                    }
                    material = new MaterialDTO();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: \n {ex.Message} \n Page : {i}");
                    material = new MaterialDTO();
                }
            }
        }



        private void InsertPresentetion(List<ApresentacaoMaterial> presentetions, int idContent)
        {
            foreach (var presentetion in presentetions)
            {
                _materialRepository.InsertPresention(presentetion, idContent);
            }
        }

        private void InsertFactory(List<Fabricantes> fabricantes, int idContent)
        {
            foreach (var fabricante in fabricantes)
            {
              _materialRepository.InsertFactory(fabricante, idContent);
            }
        }
    }
}
