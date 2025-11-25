namespace UniConnect.Argument.Argument;

public class OutputDiscussao : BaseOutput<OutputDiscussao>
{
    public int? DiscussaoPaiId { get; private set; }
    public string Titulo { get; private set; }
    public string Conteudo { get; private set; }

    public OutputDiscussao? DiscussaoPai { get; private set; }

    public OutputDiscussao() { }

    public OutputDiscussao(int? discussaoPaiId, string titulo, string conteudo)
    {
        DiscussaoPaiId = discussaoPaiId;
        Titulo = titulo;
        Conteudo = conteudo;
    }
}
