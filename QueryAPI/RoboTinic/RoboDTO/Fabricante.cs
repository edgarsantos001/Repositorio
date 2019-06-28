namespace RoboTinic.RoboDTO
{
    public class Fabricante
    {
        public int Id { get; set; }
        public string atividade { get; set; }
        public string razaoSocial { get; set; }
        public string pais { get; set; }
        public string local { get; set; }

        //public int detalheId { get; set; }
        //public Detalhe detalhe { get; set; }

        public int contentId { get; set; }
        public Content content { get; set; }

    }
}