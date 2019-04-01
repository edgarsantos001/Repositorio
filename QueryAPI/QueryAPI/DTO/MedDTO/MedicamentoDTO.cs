using System;
using System.Collections.Generic;
using System.Text;

namespace QueryAPI.DTO.MedDTO
{
    public class MedicamentoDTO
    {
        public List<ContentMedicamentoDTO> content { get; set; }
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
