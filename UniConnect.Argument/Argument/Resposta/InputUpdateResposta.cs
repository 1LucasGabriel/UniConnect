using System.Text.Json.Serialization;

namespace UniConnect.Argument.Argument;

public class InputUpdateResposta : BaseInputUpdate<InputUpdateResposta>
{
    public int DiscussaoId { get; private set; }
    public int? RespostaPaiId { get; private set; }
    public string Conteudo { get; private set; }

    public InputUpdateResposta() { }

    [JsonConstructor]
    public InputUpdateResposta(int id, int discussaoId, int? respostaPaiId, string conteudo) : base(id)
    {
        DiscussaoId = discussaoId;
        RespostaPaiId = respostaPaiId;
        Conteudo = conteudo;
    }
}
