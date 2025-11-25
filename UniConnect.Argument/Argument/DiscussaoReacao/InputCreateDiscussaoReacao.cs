using System.Text.Json.Serialization;
using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class InputCreateDiscussaoReacao : BaseInputCreate<InputCreateDiscussaoReacao>
{
    public int DiscussaoId { get; private set; }
    public TipoReacao Tipo { get; private set; }

    public InputCreateDiscussaoReacao() { }

    [JsonConstructor]
    public InputCreateDiscussaoReacao(int discussaoId, TipoReacao tipo)
    {
        DiscussaoId = discussaoId;
        Tipo = tipo;
    }
}
