namespace UniConnect.Argument.Argument;

public class OutputMensagem : BaseOutput<OutputMensagem>
{
    public string Conteudo { get; private set; }
    public bool Visualizada { get; private set; }
    public int UsuarioDestinoId { get; private set; }

    public OutputMensagem() { }

    public OutputMensagem(string conteudo, bool visualizada, int usuarioDestinoId)
    {
        Conteudo = conteudo;
        Visualizada = visualizada;
        UsuarioDestinoId = usuarioDestinoId;
    }
}
