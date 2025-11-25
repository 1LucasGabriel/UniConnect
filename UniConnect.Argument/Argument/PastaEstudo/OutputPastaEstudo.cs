using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class OutputPastaEstudo : BaseOutput<OutputPastaEstudo>
{
    public int? PastaEstudoPaiId { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public TipoVisibilidade Visibilidade { get; private set; }

    public OutputPastaEstudo? PastaPai { get; set; }

    public OutputPastaEstudo() { }

    public OutputPastaEstudo(int? pastaEstudoPaiId, string titulo, string descricao, TipoVisibilidade visibilidade)
    {
        PastaEstudoPaiId = pastaEstudoPaiId;
        Titulo = titulo;
        Descricao = descricao;
        Visibilidade = visibilidade;
    }
}
