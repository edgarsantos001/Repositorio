using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassesDTO.DTO.MatDTO
{
    public class ContentMaterial
    {
        public ContentMaterial()
        {
            apresentacoes = new List<ApresentacaoMaterial>();
          //  this.fabricantes = new HashSet<Fabricante>();
        }

        public int contentid { get; set; }
        public string processo { get; set; }
        public string produto { get; set; }
        public string registro { get; set; }
        public string situacao { get; set; }
        public string nomeTecnico { get; set; }
        public bool cancelado { get; set; }
        public string dataCancelamento { get; set; }
        public string publicacao { get; set; }
        public bool apresentacaoModelo { get; set; }
        
        public List<ApresentacaoMaterial> apresentacoes { get; set; }
        public virtual List<ContentMaterialFabricante> MaterialFabricante { get; set; }
        public virtual List<ContentClasseRisco> MaterialClasseRisco { get; set; }

        public virtual Vencimento vencimento { get; set; }
       
        //public virtual Mensagem mensagem { get; set; }

        //Foreing Keys
        public int empresaId { get; set; }
        public virtual Empresa empresa { get; set; }

        public int materialId { get; set; }
        public virtual Material material { get; set; }

        public int fabricanteId { get; set; }
        public Fabricante fabricante { get; set; }

     }
   
}