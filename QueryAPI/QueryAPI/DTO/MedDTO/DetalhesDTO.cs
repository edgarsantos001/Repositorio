using System;
using System.Collections.Generic;
using System.Text;

namespace QueryAPI.DTO
{
    public class DetalhesDTO
    {
        public int codigoProduto { get; set; }
        public int tipoProduto { get; set; }
        public string dataProduto { get; set; }
        public string nomeComercial { get; set; }
        public string numeroRegistro { get; set; }
        public string dataVencimento { get; set; }
        public string mesAnoVencimento { get; set; }
        public string codigoParecerPublico { get; set; }
        public string dataVencimentoRegistro { get; set; }
        public string principioAtivo { get; set; }
        public string medicamentoReferencia { get; set; }
<<<<<<< HEAD
        public string categoriaRegulatoria { get; set; }
=======
        public string categoriaTerapeutica { get; set; }
>>>>>>> 250e1124aac982d430b4c96b5f40c1413fb05cc0
        public string atc { get; set; }
        public string codigoBulaPaciente { get; set; }
        public string codigoBulaProfissional { get; set; }
        public EmpresaDTO empresa { get; set; }
        public processoDTO processo { get; set; }

        public List<string> rotulos { get; set; }
        public List<string> classesTerapeuticas { get; set; }
        public List<ApresentacaoDTO> apresentacoes { get; set; }
    }
<<<<<<< HEAD

    public class Rotulo
    {
        public string rotulo { get; set; }
    }

    public class ClasseTeraputica
    {
        public string classeTerapeutica_desc { get; set; }
    }
=======
>>>>>>> 250e1124aac982d430b4c96b5f40c1413fb05cc0
}
