namespace UniConnect.Domain.Entity
{
    public class Resposta : BaseEntity<Resposta>
    {
        public int DiscussaoId { get; private set; }
        public int? RespostaPaiId { get; private set; }
        public string Conteudo { get; private set; }

        public Discussao? Discussao { get; private set; }
        public Resposta? RespostaPai { get; private set; }
        public ICollection<Resposta>? SubRespostas { get; private set; }
        public ICollection<RespostaReacao>? Reacoes { get; private set; }

        public Resposta() { }

        public Resposta(int discussaoId, int? respostaPaiId, string conteudo)
        {
            DiscussaoId = discussaoId;
            RespostaPaiId = respostaPaiId;
            Conteudo = conteudo;
        }
    }
}
