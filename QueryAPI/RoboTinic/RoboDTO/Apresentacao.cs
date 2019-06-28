using System;
using System.Collections.Generic;
using System.Text;

namespace RoboTinic.RoboDTO
{
   public class Apresentacao
    {
        public int Id { get; set; }
        public string modelo { get; set; }
        public string componente { get; set; }
        public string apresentacao { get; set; }

        //public int detalheId { get; set; }
        //public Detalhe detalhe { get; set; }

        public int  contentId { get; set; }
        public Content content { get; set; }

    }
}
