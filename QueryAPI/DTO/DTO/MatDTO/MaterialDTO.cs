using System;
using System.Collections.Generic;
using System.Text;

namespace QueryAPI.DTO.MatDTO
{
    public class MaterialDTO
    {
        public List<ContentMaterialDTO> content { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
        public bool last { get; set; }
        public int numberOfElements { get; set; }
        public bool first { get; set; }
        public int? sort { get; set; }
        public int number { get; set; }
        public int size { get; set; }
    }
}
