using System.Text.Json.Serialization;

namespace UniConnect.Argument.Argument;

public class InputCreateResposta : BaseInputCreate<InputCreateResposta>
{
    public int DiscussaoId { get; private set; }
    public int? RespostaPaiId { get; private set; }
    public string Conteudo { get; private set; }

    public InputCreateResposta() { }

    [JsonConstructor]
    public InputCreateResposta(int discussaoId, int? respostaPaiId, string conteudo)
    {
        DiscussaoId = discussaoId;
        RespostaPaiId = respostaPaiId;
        Conteudo = conteudo;
    }
}
