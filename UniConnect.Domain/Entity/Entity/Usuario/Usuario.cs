using UniConnect.Argument.Enums;
using UniConnect.Infrastructure.Entity;

namespace UniConnect.Domain.Entity.Entity;

public class Usuario : BaseEntity<Usuario>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Senha { get; set; }
    public string FotoPerfilUrl { get; set; }
    public TipoUsuario TipoUsuario { get; set; }

    public Usuario() { }

    public Usuario(string nome, string email, string telefone, string senha, string fotoPerfilUrl, TipoUsuario tipoUsuario)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Senha = senha;
        FotoPerfilUrl = fotoPerfilUrl;
        TipoUsuario = tipoUsuario;
    }
}
