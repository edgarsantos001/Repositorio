using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RoboTinic.RoboDTO
{
    public class Material
    {
        public int Id { get; set; }
        public List<Content> content { get; set; }
        public int totalElements { get; set; }

        public DateTime DataAtualizacao { get; set; }

        [NotMapped]
        public int totalPages { get; set; }
        [NotMapped]
        public bool last { get; set; }
        [NotMapped]
        public bool first { get; set; }
    }
}
