using System;
using System.Collections.Generic;
using System.Text;

namespace RoboTinic.RoboDTO
{
    public class Empresa
    {
        public int id { get; set; }
        public string cnpj { get; set; }
        public string razaoSocial { get; set; }

        public int contentId { get; set; }
        public Content content { get; set; }
    }
}
