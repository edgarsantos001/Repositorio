using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassesDTO.DTO.MatDTO
{
    public class ContentMaterialDTO
    {
        public ContentMaterialDTO()
        {
            apresentacoes = new List<ApresentacaoMaterial>();
            fabricantes = new List<Fabricantes>();
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

        public virtual List<ApresentacaoMaterial> apresentacoes { get; set; }
        public virtual List<Fabricantes> fabricantes { get; set; }

        public virtual ClasseRisco risco { get; set; }
        public virtual Vencimento vencimento { get; set; }
        public virtual MensagemDTO mensagem { get; set; }

        //Foreing Keys
        public int empresaId { get; set; }
        public virtual EmpresaDTO empresa { get; set; }

        public int materialId { get; set; }
        public virtual MaterialDTO material { get; set; }

    }
    public class ApresentacaoMaterial
    {
        public string modelo { get; set; }
        public string componente { get; set; }
        public string apresentacao { get; set; }

        public int contentid { get; set; }
        public virtual ContentMaterialDTO content { get; set;}
    }
    public class Fabricantes
    {
        public string atividade { get; set; }
        public string razaoSocial { get; set; }
        public string pais { get; set; }
        public string local { get; set; }

        public int contentid { get; set; }
        public virtual ContentMaterialDTO content { get; set; }

    }

    public class ClasseRisco
    {
        public string sigla { get; set; }
        public string descricao { get; set; }

        public int contentid { get; set; }
        public virtual ContentMaterialDTO content { get; set; }

    }

    public class Vencimento
    {
        public string data { get; set; }
        public string descricao { get; set; }

        public int contentid { get; set; }
        public virtual ContentMaterialDTO content { get; set; }

    }

}