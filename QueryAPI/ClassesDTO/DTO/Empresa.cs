using ClassesDTO.DTO.MatDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesDTO.DTO
{
    public class Empresa
    {
        public Empresa()
        {
            content = new List<ContentMaterial>();
        }

        public int empresaId { get; set; }
        public string cnpj { get; set; }
        public string razaoSocial { get; set; }
        public int? numeroAutorizacao { get; set; }
        public string cnpjFormatado { get; set; }
        public string autorizacao { get; set; }

        public virtual List<ContentMaterial> content { get; set; }

    }
}
