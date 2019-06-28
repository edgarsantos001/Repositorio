using System;
using System.Collections.Generic;
using System.Text;

namespace RoboTinic.RoboDTO
{
    public class Content
    {
        public Content()
        {
            apresentacoes = new List<Apresentacao>();
            fabricantes = new List<Fabricante>();
        }

        public int id { get; set; }
        public string processo { get; set; }

        public int empresaId { get; set; }
        public Empresa empresa { get; set; }

        public string produto { get; set; }

        public Mensagem mensagem { get; set; }

        public string registro { get; set; }

        public string situacao { get; set; }

        public int materialId { get; set; }
        public Material material { get; set; }
        
        public string nomeTecnico { get; set; }

        public bool cancelamento { get; set; }

        public string dataCancelamento { get; set; }

        public List<Apresentacao> apresentacoes { get; set; }

        public List<Fabricante> fabricantes { get; set; }

        public ClasseRisco risco { get; set; }

        public Vencimento vencimento { get; set; }

        public string publicacao { get; set; }

        public bool apresentacaoModelo { get; set; }

        public bool Atualizado { get; set; }

        public bool Erro { get; set; }

    }
}
