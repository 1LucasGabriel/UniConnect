namespace UniConnect.Domain.Entity
{
    public class Discussao : BaseEntity<Discussao>
    {
        public int? DiscussaoPaiId { get; private set; }
        public string Titulo { get; private set; }
        public string Conteudo { get; private set; }

        public Discussao? DiscussaoPai { get; private set; }
        public ICollection<Discussao>? SubDiscussoes { get; private set; }
        public ICollection<Resposta>? Respostas { get; private set; }
        public ICollection<DiscussaoReacao>? Reacoes { get; private set; }

        public Discussao() { }

        public Discussao(int? discussaoPaiId, string titulo, string conteudo)
        {
            DiscussaoPaiId = discussaoPaiId;
            Titulo = titulo;
            Conteudo = conteudo;
        }
    }
}
