using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesDTO.DTO.MatDTO
{
    public class ContentClasseRisco
    {
        public int contentId { get; set; }
        public ContentMaterial Content { get; set; }

        public int classeRiscoId { get; set; }
        public ClasseRisco ClasseRisco { get; set; }
    }
}
