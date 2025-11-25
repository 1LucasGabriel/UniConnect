using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class OutputUsuario : BaseOutput<OutputUsuario>
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public string FotoPerfilUrl { get; private set; }
    public TipoUsuario TipoUsuario { get; private set; }

    public OutputUsuario(string nome, string email, string telefone, string fotoPerfilUrl, TipoUsuario tipoUsuario)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        FotoPerfilUrl = fotoPerfilUrl;
        TipoUsuario = tipoUsuario;
    }
}
