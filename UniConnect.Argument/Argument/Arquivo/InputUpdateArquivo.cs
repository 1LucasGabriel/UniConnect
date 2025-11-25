using System.Text.Json.Serialization;

namespace UniConnect.Argument.Argument;

public class InputUpdateArquivo : BaseInputUpdate<InputUpdateArquivo>
{
    public string Nome { get; private set; }
    public string Tipo { get; private set; }
    public string Url { get; private set; }
    public long TamanhoBytes { get; private set; }
    public int PastaEstudoId { get; private set; }

    public InputUpdateArquivo() { }

    [JsonConstructor]
    public InputUpdateArquivo(int id, string nome, string tipo, string url, long tamanhoBytes, int pastaEstudoId) : base(id)
    {
        Nome = nome;
        Tipo = tipo;
        Url = url;
        TamanhoBytes = tamanhoBytes;
        PastaEstudoId = pastaEstudoId;
    }
}
