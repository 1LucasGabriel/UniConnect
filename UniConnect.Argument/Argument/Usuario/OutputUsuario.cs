using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class OutputUsuario : BaseOutput<OutputUsuario>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string FotoPerfilUrl { get; set; }
    public TipoUsuario TipoUsuario { get; set; }

    public OutputUsuario(string nome, string email, string telefone, string fotoPerfilUrl, TipoUsuario tipoUsuario)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        FotoPerfilUrl = fotoPerfilUrl;
        TipoUsuario = tipoUsuario;
    }
}
