using UniConnect.Argument.Enums;

namespace UniConnect.Domain.Entity
{
    public class RespostaReacao : BaseEntity<RespostaReacao>
    {
        public int RespostaId { get; set; }
        public TipoReacao Tipo { get; set; }

        public Resposta? Resposta { get; set; }

        public RespostaReacao() { }

        public RespostaReacao(int respostaId, TipoReacao tipo)
        {
            RespostaId = respostaId;
            Tipo = tipo;
        }
    }
}
