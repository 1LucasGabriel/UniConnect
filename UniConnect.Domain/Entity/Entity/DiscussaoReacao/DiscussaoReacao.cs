using UniConnect.Argument.Enums;

namespace UniConnect.Domain.Entity
{
    public class DiscussaoReacao : BaseEntity<DiscussaoReacao>
    {
        public int DiscussaoId { get; set; }
        public TipoReacao Tipo { get; set; }

        public Discussao Discussao { get; set; }

        public DiscussaoReacao() { }

        public DiscussaoReacao(int discussaoId, TipoReacao tipo, Discussao discussao)
        {
            DiscussaoId = discussaoId;
            Tipo = tipo;
            Discussao = discussao;
        }
    }
}
