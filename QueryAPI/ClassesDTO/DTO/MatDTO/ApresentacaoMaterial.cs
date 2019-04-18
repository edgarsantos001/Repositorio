using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesDTO.DTO.MatDTO
{
    public class ApresentacaoMaterial
    {
        public int apresentacaoId { get; set; }
        public string modelo { get; set; }
        public string componente { get; set; }
        public string apresentacao { get; set; }

        public int contentid { get; set; }
        public virtual ContentMaterial content { get; set; }
    }
}
