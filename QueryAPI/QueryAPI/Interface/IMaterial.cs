using QueryAPI.DTO.MatDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryAPI.Interface
{
    public interface IMaterial
    {
      void InsertMaterial();
      void InsertPresentetion(List<ApresentacaoMaterial> presentetions, int idContent);
      void InsertFactory(List<Fabricantes> fabricantes, int idContent);
    }
}
