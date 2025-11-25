using System.Text.Json.Serialization;
using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class InputUpdatePastaEstudo : BaseInputUpdate<InputUpdatePastaEstudo>
{
    public int? PastaEstudoPaiId { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public TipoVisibilidade Visibilidade { get; private set; }

    public InputUpdatePastaEstudo() { }

    [JsonConstructor]
    public InputUpdatePastaEstudo(int id, int? pastaEstudoPaiId, string titulo, string descricao, TipoVisibilidade visibilidade) : base(id)
    {
        PastaEstudoPaiId = pastaEstudoPaiId;
        Titulo = titulo;
        Descricao = descricao;
        Visibilidade = visibilidade;
    }
}
