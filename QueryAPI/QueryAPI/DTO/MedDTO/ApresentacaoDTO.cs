using System;
using System.Collections.Generic;
using System.Text;

namespace QueryAPI.DTO
{
    public class ApresentacaoDTO
    {
        public int codigo { get; set; }
        public string apresentacao { get; set; }
        public List<string> formasFarmaceuticas { get; set; }
        public int? numero { get; set; }
        public int? totalidade { get; set; }
        public string dataPublicacao { get; set; }
        public string validade { get; set; }
        public string tipoValidade { get; set; }
        public string registro { get; set; }
        public List<string> principiosAtivos { get; set; }
        public string complemento { get; set; }
        public EmbalagemPrimaria embalagemPrimaria { get; set; }
        public EmbalagemSecundario embalagemSecundario { get; set; }
        public List<string> envoltorios { get; set; }
        public List<string> acessorios { get; set; }
        public string acondicionamento { get; set; }
        public List<string> marcas { get; set; }
        public List<FabricantesNacionais> fabricantesNacionais { get; set; }
        public List<FabricantesInternacionais> fabricantesInternacionais { get; set; }
        public List<string> viasAdministracao { get; set; }
        public bool ifaUnico { get; set; }
        public List<string> conservacao { get; set; }
        public List<string> restricaoPrescricao { get; set; }
        public List<string> restricaoUso { get; set; }
        public List<string> destinacao { get; set; }
        public string restricaoHospitais { get; set; }
        public string tarja { get; set; }
        public string medicamentoReferencia { get; set; }
        public string apresentacaoFracionada { get; set; }
        public string dataVencimentoRegistro { get; set; }
        public bool ativa { get; set; }
        public bool inativa { get; set; }
        public bool emAnalise { get; set; }


    }

    public class EmbalagemPrimaria
    {
        public string tipo { get; set; }
        public string observacao { get; set; }
    }

    public class EmbalagemSecundario
    {
        public string tipo { get; set; }
        public string observacao { get; set; }
    }

    public class FabricantesNacionais
    {
        public string fabricante { get; set; }
        public string cnpj { get; set; }
        public string pais { get; set; }
        public string uf { get; set; }
        public string cidade { get; set; }

    }
    public class FabricantesInternacionais
    {
        public string fabricante { get; set; }
        public string cnpj { get; set; }
        public string pais { get; set; }
        public string uf { get; set; }
        public string cidade { get; set; }

    }
}
