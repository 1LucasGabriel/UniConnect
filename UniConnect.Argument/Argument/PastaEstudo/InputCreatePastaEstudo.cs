using System.Text.Json.Serialization;
using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class InputCreatePastaEstudo : BaseInputCreate<InputCreatePastaEstudo>
{
    public int? PastaEstudoPaiId { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public TipoVisibilidade Visibilidade { get; private set; }

    public InputCreatePastaEstudo() { }

    [JsonConstructor]
    public InputCreatePastaEstudo(int? pastaEstudoPaiId, string titulo, string descricao, TipoVisibilidade visibilidade)
    {
        PastaEstudoPaiId = pastaEstudoPaiId;
        Titulo = titulo;
        Descricao = descricao;
        Visibilidade = visibilidade;
    }
}
