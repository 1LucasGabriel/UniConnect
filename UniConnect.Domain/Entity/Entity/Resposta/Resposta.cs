namespace UniConnect.Domain.Entity
{
    public class Resposta : BaseEntity<Resposta>
    {
        public int DiscussaoId { get; set; }
        public int? RespostaPaiId { get; set; }
        public string Conteudo { get; set; }

        public Discussao? Discussao { get; set; }
        public Resposta? RespostaPai { get; set; }
        public ICollection<Resposta>? SubRespostas { get; set; }
        public ICollection<RespostaReacao>? Reacoes { get; set; }

        public Resposta() { }

        public Resposta(int discussaoId, int? respostaPaiId, string conteudo)
        {
            DiscussaoId = discussaoId;
            RespostaPaiId = respostaPaiId;
            Conteudo = conteudo;
        }
    }
}
