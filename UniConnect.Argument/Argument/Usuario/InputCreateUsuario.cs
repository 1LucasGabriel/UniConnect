using System.Text.Json.Serialization;
using UniConnect.Argument.Enums;

namespace UniConnect.Argument.Argument;

public class InputCreateUsuario : BaseInputCreate<InputCreateUsuario>
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public string Senha { get; private set; }
    public string FotoPerfilUrl { get; private set; }
    public TipoUsuario TipoUsuario { get; private set; }

    [JsonConstructor]
    public InputCreateUsuario(string nome, string email, string telefone, string senha, string fotoPerfilUrl, TipoUsuario tipoUsuario)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Senha = senha;
        FotoPerfilUrl = fotoPerfilUrl;
        TipoUsuario = tipoUsuario;
    }
}
