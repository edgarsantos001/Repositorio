using System;
using System.Collections.Generic;
using System.Text;

namespace QueryAPI.DTO
{
    public class EmpresaDTO
    {
        public string cnpj { get; set; }
        public string razaoSocial { get; set; }
        public int? numeroAutorizacao { get; set; }
        public string cnpjFormatado { get; set; }
        public string autorizacao { get; set; }
    }
}
