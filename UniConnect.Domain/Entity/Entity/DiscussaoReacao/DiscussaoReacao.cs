using UniConnect.Argument.Enums;

namespace UniConnect.Domain.Entity
{
    public class DiscussaoReacao : BaseEntity<DiscussaoReacao>
    {
        public int DiscussaoId { get; private set; }
        public TipoReacao Tipo { get; private set; }

        public Discussao Discussao { get; private set; }

        public DiscussaoReacao() { }

        public DiscussaoReacao(int discussaoId, TipoReacao tipo, Discussao discussao)
        {
            DiscussaoId = discussaoId;
            Tipo = tipo;
            Discussao = discussao;
        }
    }
}
