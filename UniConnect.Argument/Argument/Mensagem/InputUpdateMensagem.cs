using System.Text.Json.Serialization;

namespace UniConnect.Argument.Argument;

public class InputUpdateMensagem : BaseInputUpdate<InputUpdateMensagem>
{
    public string Conteudo { get; private set; }
    public bool Visualizada { get; private set; }
    public int UsuarioDestinoId { get; private set; }

    public InputUpdateMensagem() { }

    [JsonConstructor]
    public InputUpdateMensagem(int id, string conteudo, bool visualizada, int usuarioDestinoId) : base(id)
    {
        Conteudo = conteudo;
        Visualizada = visualizada;
        UsuarioDestinoId = usuarioDestinoId;
    }
}
