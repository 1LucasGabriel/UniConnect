namespace UniConnect.Argument.Argument;

public class OutputResposta : BaseOutput<OutputResposta>
{
    public int DiscussaoId { get; private set; }
    public int? RespostaPaiId { get; private set; }
    public string Conteudo { get; private set; }

    public OutputResposta() { }

    public OutputResposta(int discussaoId, int? respostaPaiId, string conteudo)
    {
        DiscussaoId = discussaoId;
        RespostaPaiId = respostaPaiId;
        Conteudo = conteudo;
    }
}
