using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesDTO.DTO.MatDTO
{
    public class Fabricante
    {
        public Fabricante()
        {
            content = new List<ContentMaterial>();
        }

        public int fabricanteId { get; set; }
        public string atividade { get; set; }
        public string razaoSocial { get; set; }
        public string pais { get; set; }
        public string local { get; set; }

        public virtual List<ContentMaterial> content { get; set; }
        
    }
}
