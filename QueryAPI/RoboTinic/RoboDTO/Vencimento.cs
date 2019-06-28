namespace RoboTinic.RoboDTO
{
    public class Vencimento
    {
        public int Id { get; set; }
        public string data { get; set; }
        public string descricao { get; set; }

        //public int detalheId { get; set; }
        //public Detalhe detalhe { get; set; }

        public int contentId { get; set; }
        public Content content { get; set; }

    }
}