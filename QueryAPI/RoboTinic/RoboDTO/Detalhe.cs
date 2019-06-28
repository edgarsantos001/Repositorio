using System.Collections.Generic;

namespace RoboTinic.RoboDTO
{
    public class Detalhe
    {
        public int Id { get; set; }
        public string nomeTecnico { get; set; }
        public string registro { get; set; }
        public bool cancelamento { get; set; }
        public string dataCancelamento { get; set; }
        public string processo { get; set; }
        public List<Apresentacao> apresentacoes { get; set; }
        public List<Fabricante> fabricantes { get; set; }
        public ClasseRisco risco { get; set; }
        public Vencimento vencimento { get; set; }
        public string publicacao { get; set; }
        public bool apresentacaoModelo { get; set; }
    }
}
