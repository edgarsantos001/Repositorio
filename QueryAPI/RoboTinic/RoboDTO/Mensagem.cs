using System;
using System.Collections.Generic;
using System.Text;

namespace RoboTinic.RoboDTO
{
    public class Mensagem
    {
        public int id { get; set; }

        public string situacao { get; set; }

        public string resolucao { get; set; }

        public string motivo { get; set; }

        public bool negativo { get; set; }

        public int contentId { get; set; }
        public Content content { get; set; }
    }
}
