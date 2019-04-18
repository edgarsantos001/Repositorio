using MatDTO.ClassesDTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesDTO.DTO
{
    public class ContentMedicamentoDTO
    {
        public int orderm { get; set; }
        public Produto produto { get; set; }
        public Empresa empresa { get; set; }
        public Processo processo { get; set; }
    }
}
