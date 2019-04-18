using System.Collections.Generic;

namespace ClassesDTO.DTO.MatDTO
{
    public class ClasseRisco
    {
        public int classeRiscoId { get; set; }
        public string sigla { get; set; }
        public string descricao { get; set; }

        public List<ContentClasseRisco> MaterialClasseRisco { get; set; }
    }
}
