using System;
using System.Collections.Generic;
using System.Text;

namespace QueryAPI.DTO
{
    public class produtoDTO
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public long numeroRegistro { get; set; }
        public tipoDTO tipo { get; set; }
        public string categoria { get; set; }
        public string situacaoRotulo { get; set; }
        public string dataVencimento { get; set; }
        public string mesAnoVencimento { get; set; }
        public string dataVencimentoRegistro { get; set; }
        public string principioAtivo { get; set; }
        public string situacaoApresentacao { get; set; }
        public string dataRegistro { get; set; }
        public bool acancelar { get; set; }
        public long numeroRegistroFormatado { get; set; }
        public string mesAnoVencimentoFormatado { get; set; }

    }
}
