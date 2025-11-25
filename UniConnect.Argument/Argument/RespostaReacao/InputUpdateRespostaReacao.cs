using System.Text.Json.Serialization;
using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class InputUpdateRespostaReacao : BaseInputUpdate<InputUpdateRespostaReacao>
{
    public int RespostaId { get; private set; }
    public TipoReacao Tipo { get; private set; }

    public InputUpdateRespostaReacao() { }

    [JsonConstructor]
    public InputUpdateRespostaReacao(int id, int respostaId, TipoReacao tipo) : base(id)
    {
        RespostaId = respostaId;
        Tipo = tipo;
    }
}
