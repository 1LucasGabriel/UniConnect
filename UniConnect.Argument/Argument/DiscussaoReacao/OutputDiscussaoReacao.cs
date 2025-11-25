using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class OutputDiscussaoReacao : BaseOutput<OutputDiscussaoReacao>
{
    public int DiscussaoId { get; private set; }
    public TipoReacao Tipo { get; private set; }

    public OutputDiscussaoReacao() { }

    public OutputDiscussaoReacao(int discussaoId, TipoReacao tipo)
    {
        DiscussaoId = discussaoId;
        Tipo = tipo;
    }
}
