using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class InputUpdateUsuario : BaseInputUpdate<InputUpdateUsuario>
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string FotoPerfilUrl { get; set; }
    public TipoUsuario TipoUsuario { get; set; }

    public InputUpdateUsuario(int id, string nome, string telefone, string fotoPerfilUrl, TipoUsuario tipoUsuario) : base(id)
    {
        Nome = nome;
        Telefone = telefone;
        FotoPerfilUrl = fotoPerfilUrl;
        TipoUsuario = tipoUsuario;
    }
}
