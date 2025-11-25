using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class OutputRespostaReacao : BaseOutput<OutputRespostaReacao>
{
    public int RespostaId { get; private set; }
    public TipoReacao Tipo { get; private set; }

    public OutputRespostaReacao() { }

    public OutputRespostaReacao(int respostaId, TipoReacao tipo)
    {
        RespostaId = respostaId;
        Tipo = tipo;
    }
}
