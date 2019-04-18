using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesDTO.DTO.MatDTO
{
    public class Vencimento
    {
        public int vencimentoId { get; set; }
        public string data { get; set; }
        public string descricao { get; set; }

        public int contentid { get; set; }
        public virtual ContentMaterial content { get; set; }
    }
}
