namespace UniConnect.Domain.Entity
{
    public class Discussao : BaseEntity<Discussao>
    {
        public int? DiscussaoPaiId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }

        public Discussao? DiscussaoPai { get; set; }
        public ICollection<Discussao>? SubDiscussoes { get; set; }
        public ICollection<Resposta>? Respostas { get; set; }
        public ICollection<DiscussaoReacao>? Reacoes { get; set; }

        public Discussao() { }

        public Discussao(int? discussaoPaiId, string titulo, string conteudo)
        {
            DiscussaoPaiId = discussaoPaiId;
            Titulo = titulo;
            Conteudo = conteudo;
        }
    }
}
