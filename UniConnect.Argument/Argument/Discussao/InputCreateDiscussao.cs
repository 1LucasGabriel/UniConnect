using System.Text.Json.Serialization;

namespace UniConnect.Argument.Argument;

public class InputCreateDiscussao : BaseInputCreate<InputCreateDiscussao>
{
    public int? DiscussaoPaiId { get; private set; }
    public string Titulo { get; private set; }
    public string Conteudo { get; private set; }

    public InputCreateDiscussao() { }

    [JsonConstructor]
    public InputCreateDiscussao(int? discussaoPaiId, string titulo, string conteudo)
    {
        DiscussaoPaiId = discussaoPaiId;
        Titulo = titulo;
        Conteudo = conteudo;
    }
}
