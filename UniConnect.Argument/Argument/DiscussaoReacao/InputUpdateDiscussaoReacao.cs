using System.Text.Json.Serialization;
using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class InputUpdateDiscussaoReacao : BaseInputUpdate<InputUpdateDiscussaoReacao>
{
    public int DiscussaoId { get; private set; }
    public TipoReacao Tipo { get; private set; }

    public InputUpdateDiscussaoReacao() { }

    [JsonConstructor]
    public InputUpdateDiscussaoReacao(int id, int discussaoId, TipoReacao tipo) : base(id)
    {
        DiscussaoId = discussaoId;
        Tipo = tipo;
    }
}
