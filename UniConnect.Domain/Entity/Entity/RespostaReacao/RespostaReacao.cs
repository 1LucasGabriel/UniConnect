using UniConnect.Argument.Enums;

namespace UniConnect.Domain.Entity
{
    public class RespostaReacao : BaseEntity<RespostaReacao>
    {
        public int RespostaId { get; private set; }
        public TipoReacao Tipo { get; private set; }

        public Resposta? Resposta { get; private set; }

        public RespostaReacao() { }

        public RespostaReacao(int respostaId, TipoReacao tipo)
        {
            RespostaId = respostaId;
            Tipo = tipo;
        }
    }
}
