using QueryAPI.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryAPI.Interface
{
    public interface IMedicamentoRepository
    {
        int InsertMaterial(DetalhesDTO detalheMedicamentoDTO);
        int InsertMaterialContent(ContentMedicamentoDTO contentMaterialDTO);
        void InsertFactory(ApresentacaoDTO apresentacao, int idMedicamento);
    }
}
