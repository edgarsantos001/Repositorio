namespace RoboTinic.RoboDTO
{
    public class ClasseRisco
    {
        public int Id { get; set; }
        public string sigla { get; set; }
        public string descricao { get; set; }

        //public int detalheId { get; set; }
        //public Detalhe detalhe { get; set; }

        public int contentId { get; set; }
        public Content content { get; set; }

    }

}