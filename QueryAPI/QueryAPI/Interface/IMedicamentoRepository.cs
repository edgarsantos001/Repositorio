using QueryAPI.DTO;
using QueryAPI.DTO.MedDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryAPI.Interface
{
    public interface IMedicamentoRepository
    {
        int InsertApresentacao(ApresentacaoDTO apresentacoes, int idMedDet);
        int InsertDetalheMedicamento(DetalhesDTO detalheMedicamentoDTO);
        void InsertFactory(FabricanteDTO fabricante, int idMedicamento, char tipo);
        int InsertMedicamentoContent(ContentMedicamentoDTO contentMaterialDTO);
        void InsertRotulos(string desc, int idMedDetalhe);
        void InsertClasseTerapeutica(string desc, int idMedDetalhe);
        void InsertFormasFarmaceuticas(string formasFarmaceuticas, int idMedDet);
        void InsertDestinacao(string destinacao, int idMedDet);
        void InsertRestricaoUso(string restricaoUso, int idMedDet);
        void InsertRestricaoPrescricao(string restricaoPrescricao, int idMedDet);
        void InsertConservacao(string conservacao, int idMedDet);
        void InsertPrincipioAtivo(string principiosAtivos, int idMedDet);
        void InsertViasAdministracao(string viasAdministracao, int idMedDet);
        void InsertMarcas(string marcas, int idMedDet);
        void InsertAcessorios(Acessorio acessorios, int idMedDet);
        void InsertEnvoltorio(string envoltorios, int idMedDet);
        
    }   
    //    int InsertMaterial(DetalhesDTO detalheMedicamentoDTO);
    //    int InsertMaterialContent(ContentMedicamentoDTO contentMaterialDTO);
    //    void InsertFactory(ApresentacaoDTO apresentacao, int idMedicamento);
    //}
}
