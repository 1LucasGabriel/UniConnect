using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class InputUpdateUsuario : BaseInputUpdate<InputUpdateUsuario>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Senha { get; set; }
    public string FotoPerfilUrl { get; set; }
    public TipoUsuario TipoUsuario { get; set; }

    public InputUpdateUsuario(int id, string nome, string email, string telefone, string senha, string fotoPerfilUrl, TipoUsuario tipoUsuario) : base(id)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Senha = senha;
        FotoPerfilUrl = fotoPerfilUrl;
        TipoUsuario = tipoUsuario;
    }
}
