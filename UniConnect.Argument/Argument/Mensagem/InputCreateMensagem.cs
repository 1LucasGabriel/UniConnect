using System.Text.Json.Serialization;

namespace UniConnect.Argument.Argument;

public class InputCreateMensagem : BaseInputCreate<InputCreateMensagem>
{
    public string Conteudo { get; private set; }
    public bool Visualizada { get; private set; }
    public int UsuarioDestinoId { get; private set; }

    public InputCreateMensagem() { }

    [JsonConstructor]
    public InputCreateMensagem(string conteudo, bool visualizada, int usuarioDestinoId)
    {
        Conteudo = conteudo;
        Visualizada = visualizada;
        UsuarioDestinoId = usuarioDestinoId;
    }
}
