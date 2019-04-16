using ClassesDTO;
using System.Collections.Generic;

namespace QueryAPI.DTO.MatDTO
{
    public class ContentMaterialDTO
    {
        public int idMaterial { get; set; }
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
        public List<Fabricantes> fabricantes { get; set; }
        public ClasseRisco risco { get; set; }
        public Vencimento vencimento { get; set; }
        public MensagemDTO mensagem { get; set; }
        public EmpresaDTO empresa { get; set; }
    }
    public class ApresentacaoMaterial
    {
        public string modelo { get; set; }
        public string componente { get; set; }
        public string apresentacao { get; set; }
    }
    public class Fabricantes
    {
        public string atividade { get; set; }
        public string razaoSocial { get; set; }
        public string pais { get; set; }
        public string local { get; set; }
    }

    public class ClasseRisco
    {
        public string sigla { get; set; }
        public string descricao { get; set; }
    }

    public class Vencimento
    {
        public string data { get; set; }
        public string descricao { get; set; }

    }

}