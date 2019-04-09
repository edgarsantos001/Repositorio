using QueryAPI.DTO;
<<<<<<< HEAD
using QueryAPI.DTO.MedDTO;
=======
>>>>>>> 250e1124aac982d430b4c96b5f40c1413fb05cc0
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryAPI.Interface
{
    public interface IMedicamentoRepository
    {
<<<<<<< HEAD
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
=======
        int InsertMaterial(DetalhesDTO detalheMedicamentoDTO);
        int InsertMaterialContent(ContentMedicamentoDTO contentMaterialDTO);
        void InsertFactory(ApresentacaoDTO apresentacao, int idMedicamento);
    }
>>>>>>> 250e1124aac982d430b4c96b5f40c1413fb05cc0
}
