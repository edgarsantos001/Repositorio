using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassesDTO.DTO.MatDTO
{
    public class MaterialDTO
    {
        public MaterialDTO()
        {
            content = new List<ContentMaterialDTO>(); 
        }

        public int materialId { get; set; }
        public int totalElementsID { get; set; }
        public int totalPages { get; set; }
        public bool last { get; set; }
        public int numberOfElements { get; set; }
        public bool first { get; set; }
        public int? sort { get; set; }
        public int number { get; set; }
        public int size { get; set; }

        public virtual List<ContentMaterialDTO> content { get; set; }
    }

}
