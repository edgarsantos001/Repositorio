using QueryAPI.DTO.MatDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryAPI.Interface
{
    public interface IMaterialRepository
    {
        int InsertMaterial(MaterialDTO materialDTO);
        int InsertMaterialContent(ContentMaterialDTO contentMaterialDTO);
        void InsertFactory(Fabricantes fabricantes, int idContent);
        void InsertPresention(ApresentacaoMaterial presention, int idContent);
    }

}
