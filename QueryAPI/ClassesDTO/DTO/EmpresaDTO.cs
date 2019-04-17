using ClassesDTO.DTO.MatDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesDTO.DTO
{
    public class EmpresaDTO
    {
        public EmpresaDTO()
        {
            content = new List<ContentMaterialDTO>();
        }


        public int empresaId { get; set; }
        public string cnpj { get; set; }
        public string razaoSocial { get; set; }
        public int? numeroAutorizacao { get; set; }
        public string cnpjFormatado { get; set; }
        public string autorizacao { get; set; }

        public virtual List<ContentMaterialDTO> content { get; set; }

    }
}
