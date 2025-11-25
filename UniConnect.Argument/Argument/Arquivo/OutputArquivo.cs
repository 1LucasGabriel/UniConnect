namespace UniConnect.Argument.Argument;

public class OutputArquivo : BaseOutput<OutputArquivo>
{
    public string Nome { get; private set; }
    public string Tipo { get; private set; }
    public string Url { get; private set; }
    public long TamanhoBytes { get; private set; }
    public int PastaEstudoId { get; private set; }

    public OutputArquivo() { }

    public OutputArquivo(string nome, string tipo, string url, long tamanhoBytes, int pastaEstudoId)
    {
        Nome = nome;
        Tipo = tipo;
        Url = url;
        TamanhoBytes = tamanhoBytes;
        PastaEstudoId = pastaEstudoId;
    }
}
