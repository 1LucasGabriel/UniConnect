using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class InputUpdateUsuario : BaseInputUpdate<InputUpdateUsuario>
{
    public string Nome { get; private set; }
    public string Telefone { get; private set; }
    public string FotoPerfilUrl { get; private set; }
    public TipoUsuario TipoUsuario { get; private set; }

    public InputUpdateUsuario(int id, string nome, string telefone, string fotoPerfilUrl, TipoUsuario tipoUsuario) : base(id)
    {
        Nome = nome;
        Telefone = telefone;
        FotoPerfilUrl = fotoPerfilUrl;
        TipoUsuario = tipoUsuario;
    }
}
