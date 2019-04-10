
﻿using Microsoft.Extensions.Logging;
using QueryAPI.DTO;
using QueryAPI.DTO.MatDTO;
using QueryAPI.DTO.MedDTO;
using QueryAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            string link = "https://consultas.anvisa.gov.br/api/consulta/medicamento/produtos/";
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
                       InsertFactoryInter(apresentacao.fabricantesInternacionais, apresentacao_id);

                    if (apresentacao.fabricantesNacionais.Any())
                        InsertFactoryNac(apresentacao.fabricantesNacionais, apresentacao_id);

                    if (apresentacao.envoltorios.Any())
                        InsertEnvoltorio(apresentacao.envoltorios, apresentacao_id);

                    if (apresentacao.acessorios.Any())
                        InsertAcessorios(apresentacao.acessorios, apresentacao_id);

                    if (apresentacao.marcas.Any())
                        InsertMarcas(apresentacao.marcas, apresentacao_id);

                    if (apresentacao.viasAdministracao.Any())
                        InsertViasAdministracao(apresentacao.viasAdministracao, apresentacao_id);

                    if (apresentacao.principiosAtivos.Any())
                        InsertPrincipioAtivo(apresentacao.principiosAtivos, apresentacao_id);

                    if (apresentacao.conservacao.Any())
                        InsertConservacao(apresentacao.conservacao, apresentacao_id);

                    if (apresentacao.restricaoPrescricao.Any())
                        InsertRestricaoPrescricao(apresentacao.restricaoPrescricao, apresentacao_id);

                    if (apresentacao.restricaoUso.Any())
                        InsertRestricaoUso(apresentacao.restricaoUso, apresentacao_id);

                    if (apresentacao.destinacao.Any())
                        InsertDestinacao(apresentacao.destinacao, apresentacao_id);

                    if (apresentacao.formasFarmaceuticas.Any())
                        InsertFormasFarmaceuticas(apresentacao.formasFarmaceuticas, apresentacao_id);
                }
            }
        }

        public void InsertFormasFarmaceuticas(List<string> formasFarmaceuticas, int apresentacao_id)
        {
            foreach (var forma in formasFarmaceuticas)
            {
                if (!String.IsNullOrEmpty(forma))
                _medicamentoRepository.InsertFormasFarmaceuticas(forma, apresentacao_id);

            }
        }

        public void InsertDestinacao(List<string> destinacoes, int apresentacao_id)
        {
            foreach (var dest in destinacoes)
            {
                if (!String.IsNullOrEmpty(dest))
                    _medicamentoRepository.InsertDestinacao(dest, apresentacao_id);
            }
        }

        public void InsertRestricaoUso(List<string> restricoesUso, int apresentacao_id)
        {
            foreach (var retuso in restricoesUso)
            {
                if (!String.IsNullOrEmpty(retuso))
                    _medicamentoRepository.InsertRestricaoUso(retuso, apresentacao_id);
            }
        }

        public void InsertRestricaoPrescricao(List<string> restricoesPrescricoes, int apresentacao_id)
        {
            foreach (var restp in restricoesPrescricoes)
            {
                if (!String.IsNullOrEmpty(restp))
                    _medicamentoRepository.InsertRestricaoPrescricao(restp, apresentacao_id);
            }
        }

        public void InsertConservacao(List<string> conservacoes, int apresentacao_id)
        {
            foreach (var conser in conservacoes)
            {
                if (!String.IsNullOrEmpty(conser))
                    _medicamentoRepository.InsertConservacao(conser, apresentacao_id);
            }
        }

        public void InsertPrincipioAtivo(List<string> principiosAtivos, int apresentacao_id)
        {
            foreach (var prinAt in principiosAtivos)
            {
                if (!String.IsNullOrEmpty(prinAt))
                    _medicamentoRepository.InsertPrincipioAtivo(prinAt, apresentacao_id);

            }
        }

        public void InsertViasAdministracao(List<string> viasAdministracao, int apresentacao_id)
        {
            foreach (var viaAdm in viasAdministracao)
            {
                if (!String.IsNullOrEmpty(viaAdm))
                    _medicamentoRepository.InsertViasAdministracao(viaAdm, apresentacao_id);
            }
        }

        public void InsertMarcas(List<string> marcas, int apresentacao_id)
        {
            foreach (var marca in marcas)
            {
                if (!String.IsNullOrEmpty(marca))
                    _medicamentoRepository.InsertMarcas(marca, apresentacao_id);
            }
        }

        public void InsertAcessorios(List<Acessorio> acessorios, int apresentacao_id)
        {
            foreach (var acessorio in acessorios)
            {
                _medicamentoRepository.InsertAcessorios(acessorio, apresentacao_id);
            }
        }

        public void InsertEnvoltorio(List<string> envoltorios, int apresentacao_id)
        {
            foreach (var env in envoltorios)
            {
                if (!String.IsNullOrEmpty(env))
                    _medicamentoRepository.InsertEnvoltorio(env, apresentacao_id);
                else
                    _logger.LogWarning($"ENVOLTORIOS: \n {envoltorios}");
            } 
        }

        public void InsertFactoryNac(List<FabricantesNacionais> fabricantes, int apresentacao_id)
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
                _medicamentoRepository.InsertFactory(fab, apresentacao_id, 'N');
            } 
        }

        public void InsertFactoryInter(List<FabricantesInternacionais> fabricantes, int apresentacao_id)
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
                _medicamentoRepository.InsertFactory(fab, apresentacao_id, 'I');
            }
        }

    }
}
