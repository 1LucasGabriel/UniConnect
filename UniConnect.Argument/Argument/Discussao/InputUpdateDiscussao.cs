using System.Text.Json.Serialization;

namespace UniConnect.Argument.Argument;

public class InputUpdateDiscussao : BaseInputUpdate<InputUpdateDiscussao>
{
    public int? DiscussaoPaiId { get; private set; }
    public string Titulo { get; private set; }
    public string Conteudo { get; private set; }

    public InputUpdateDiscussao() { }

    [JsonConstructor]
    public InputUpdateDiscussao(int id, int? discussaoPaiId, string titulo, string conteudo) : base(id)
    {
        DiscussaoPaiId = discussaoPaiId;
        Titulo = titulo;
        Conteudo = conteudo;
    }
}
