using System.Text.Json.Serialization;
using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class InputCreateRespostaReacao : BaseInputCreate<InputCreateRespostaReacao>
{
    public int RespostaId { get; private set; }
    public TipoReacao Tipo { get; private set; }

    public InputCreateRespostaReacao() { }

    [JsonConstructor]
    public InputCreateRespostaReacao(int respostaId, TipoReacao tipo)
    {
        RespostaId = respostaId;
        Tipo = tipo;
    }
}
