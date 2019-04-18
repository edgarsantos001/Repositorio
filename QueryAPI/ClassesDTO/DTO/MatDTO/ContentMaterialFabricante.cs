using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesDTO.DTO.MatDTO
{
    public class ContentMaterialFabricante
    {
        public int contentId { get; set; }
        public ContentMaterial Content { get; set; }
        public int fabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}
