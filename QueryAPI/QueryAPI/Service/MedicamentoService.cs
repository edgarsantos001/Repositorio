using Microsoft.Extensions.Logging;
using QueryAPI.DTO;
using QueryAPI.DTO.MatDTO;
using QueryAPI.DTO.MedDTO;
using QueryAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueryAPI.Service
{
    public class MedicamentoService : IMedicamento
    {
        private readonly IMedicamentoRepository _medicamentoRepository;
        private readonly ILogger<MedicamentoService> _logger;
        public MedicamentoService(ILogger<MedicamentoService> logger, IMedicamentoRepository medicamentoRepository)
        {
            _logger = logger;
            _medicamentoRepository = medicamentoRepository;
        }

        public void InsertMedicamento()
        {
            //https://consultas.anvisa.gov.br/api/consulta/medicamento/produtos/?count=10&filter%5BcategoriasRegulatorias%5D=1,2,3,4,5,6,7,8&page=1
            string link = "https://consultas.anvisa.gov.br/api/consulta/medicamento/produtos/";
            //"?count=10&filter%5Btarjas%5D=1,2,3,4&page={0}";
            //  int pagesCount = 419;

            //for (int i = 1; i < pagesCount; i++)
            //{
            //    MedicamentoDTO medicamento = Utils.ResultRequestJson<MedicamentoDTO>(string.Format(link + "?count=100&filter%5Btarjas%5D=1,2,3,4,5,6,7,8&page={0}", i));

            //    foreach (ContentMedicamentoDTO med in medicamento.content)
            //    {
            //        DetalhesDTO detalhe = Utils.ResultRequestJson<DetalhesDTO>(link + med.processo.numero);
            //        detalhe.processo = med.processo;
            //    }
            //}

            int pagesCount = 1;
            bool existData = true;
            while (existData)
            {
                MedicamentoDTO medicamento = Utils.ResultRequestJson<MedicamentoDTO>(string.Format(link + "?count=1000&filter%5Btarjas%5D=1,2,3,4&page={0}", pagesCount));
                pagesCount++;
                if (medicamento.content.Any())
                {
                    foreach (ContentMedicamentoDTO med in medicamento.content)
                    {
                        DetalhesDTO detalhe = Utils.ResultRequestJson<DetalhesDTO>(link + med.processo.numero);
                        detalhe.processo = med.processo;

                        int idMedDet = _medicamentoRepository.InsertDetalheMedicamento(detalhe);
                        if (idMedDet != 0)
                        {
                            InsertRotulo(detalhe.rotulos, idMedDet);
                            InsertClasseTerapeutica(detalhe.classesTerapeuticas, idMedDet);

                            InsertPresentetion(detalhe.apresentacoes, idMedDet);


                        }

                        Console.WriteLine($"Produto: {med.produto.nome} \n Registro: {med.produto.numeroRegistro}..");
                    }
                }

                if (medicamento.last && medicamento.numberOfElements == 0)
                    existData = false;
            }
        }
        
        public void InsertRotulo(List<string> rotulos, int idMedDet )
        {
            if (rotulos.Any())
            {
                foreach (string rotulo in rotulos)
                {
                    _medicamentoRepository.InsertRotulos(rotulo, idMedDet);
                }
            }
        }

        public void InsertClasseTerapeutica(List<string> classesTeraputicas, int idMedDet)
        {
            if (classesTeraputicas.Any())
            {
                foreach (string classe in classesTeraputicas)
                {
                    _medicamentoRepository.InsertClasseTerapeutica(classe, idMedDet);
                }
            }
        }

        public void InsertPresentetion(List<ApresentacaoDTO> apresentacoes, int idMedDet)
        {
            if (apresentacoes.Any())
            {
                foreach (ApresentacaoDTO apresentacao in apresentacoes)
                {
                  int apresentacao_id =  _medicamentoRepository.InsertApresentacao(apresentacao, idMedDet);

                    if (apresentacao.fabricantesInternacionais.Any())
                       InsertFactoryInter(apresentacao.fabricantesInternacionais, idMedDet);

                    if (apresentacao.fabricantesNacionais.Any())
                        InsertFactoryNac(apresentacao.fabricantesNacionais, idMedDet);

                    if (apresentacao.envoltorios.Any())
                        InsertEnvoltorio(apresentacao.envoltorios, idMedDet);

                    if (apresentacao.acessorios.Any())
                        InsertAcessorios(apresentacao.acessorios, idMedDet);

                    if (apresentacao.marcas.Any())
                        InsertMarcas(apresentacao.marcas, idMedDet);

                    if (apresentacao.viasAdministracao.Any())
                        InsertViasAdministracao(apresentacao.viasAdministracao, idMedDet);

                    if (apresentacao.principiosAtivos.Any())
                        InsertPrincipioAtivo(apresentacao.principiosAtivos, idMedDet);

                    if (apresentacao.conservacao.Any())
                        InsertConservacao(apresentacao.conservacao, idMedDet);

                    if (apresentacao.restricaoPrescricao.Any())
                        InsertRestricaoPrescricao(apresentacao.restricaoPrescricao, idMedDet);

                    if (apresentacao.restricaoUso.Any())
                        InsertRestricaoUso(apresentacao.restricaoUso, idMedDet);

                    if (apresentacao.destinacao.Any())
                        InsertDestinacao(apresentacao.destinacao, idMedDet);

                    if (apresentacao.formasFarmaceuticas.Any())
                        InsertFormasFarmaceuticas(apresentacao.formasFarmaceuticas, idMedDet);
                }
            }
        }

        public void InsertFormasFarmaceuticas(List<string> formasFarmaceuticas, int idMedDet)
        {
            foreach (var forma in formasFarmaceuticas)
            {
                if (!String.IsNullOrEmpty(forma))
                _medicamentoRepository.InsertFormasFarmaceuticas(forma, idMedDet);

            }
        }

        public void InsertDestinacao(List<string> destinacoes, int idMedDet)
        {
            foreach (var dest in destinacoes)
            {
                if (!String.IsNullOrEmpty(dest))
                    _medicamentoRepository.InsertDestinacao(dest, idMedDet);
            }
        }

        public void InsertRestricaoUso(List<string> restricoesUso, int idMedDet)
        {
            foreach (var retuso in restricoesUso)
            {
                if (!String.IsNullOrEmpty(retuso))
                    _medicamentoRepository.InsertRestricaoUso(retuso, idMedDet);
            }
        }

        public void InsertRestricaoPrescricao(List<string> restricoesPrescricoes, int idMedDet)
        {
            foreach (var restp in restricoesPrescricoes)
            {
                if (!String.IsNullOrEmpty(restp))
                    _medicamentoRepository.InsertRestricaoPrescricao(restp, idMedDet);
            }
        }

        public void InsertConservacao(List<string> conservacoes, int idMedDet)
        {
            foreach (var conser in conservacoes)
            {
                if (!String.IsNullOrEmpty(conser))
                    _medicamentoRepository.InsertConservacao(conser, idMedDet);
            }
        }

        public void InsertPrincipioAtivo(List<string> principiosAtivos, int idMedDet)
        {
            foreach (var prinAt in principiosAtivos)
            {
                if (!String.IsNullOrEmpty(prinAt))
                    _medicamentoRepository.InsertPrincipioAtivo(prinAt, idMedDet);

            }
        }

        public void InsertViasAdministracao(List<string> viasAdministracao, int idMedDet)
        {
            foreach (var viaAdm in viasAdministracao)
            {
                if (!String.IsNullOrEmpty(viaAdm))
                    _medicamentoRepository.InsertViasAdministracao(viaAdm, idMedDet);
            }
        }

        public void InsertMarcas(List<string> marcas, int idMedDet)
        {
            foreach (var marca in marcas)
            {
                if (!String.IsNullOrEmpty(marca))
                    _medicamentoRepository.InsertMarcas(marca, idMedDet);
            }
        }

        public void InsertAcessorios(List<Acessorio> acessorios, int idMedDet)
        {
            foreach (var acessorio in acessorios)
            {
                _medicamentoRepository.InsertAcessorios(acessorio, idMedDet);
            }
        }

        public void InsertEnvoltorio(List<string> envoltorios, int idMedDet)
        {
            foreach (var env in envoltorios)
            {
                if (!String.IsNullOrEmpty(env))
                    _medicamentoRepository.InsertEnvoltorio(env, idMedDet);
                else
                    _logger.LogWarning($"ENVOLTORIOS: \n {envoltorios}");
            } 
        }

        public void InsertFactoryNac(List<FabricantesNacionais> fabricantes, int idContent)
        {
            foreach (var itemFab in fabricantes)
            {
                FabricanteDTO fab = new FabricanteDTO()
                {
                      CIDADE = itemFab.cidade,
                      CNPJ = itemFab.cnpj,
                      ENDERECO = itemFab.endereco,
                      PAIS = itemFab.pais,
                      RAZAO_SOCIAL = itemFab.fabricante,
                      UF = itemFab.uf
                };
                _medicamentoRepository.InsertFactory(fab, idContent, 'N');
            } 
        }

        public void InsertFactoryInter(List<FabricantesInternacionais> fabricantes, int idContent)
        {
            foreach (var itemFab in fabricantes)
            {
                FabricanteDTO fab = new FabricanteDTO()
                {
                    CIDADE = string.Empty,
                    CNPJ = string.Empty,
                    ENDERECO = itemFab.endereco,
                    PAIS = itemFab.pais,
                    RAZAO_SOCIAL = itemFab.fabricante,
                    UF = string.Empty
                };
                _medicamentoRepository.InsertFactory(fab, idContent, 'I');
            }
        }
    }
}
