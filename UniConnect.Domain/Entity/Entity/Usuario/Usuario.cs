using UniConnect.Argument.Enums;

namespace UniConnect.Domain.Entity;

public class Usuario : BaseEntity<Usuario>
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public string Senha { get; private set; }
    public string FotoPerfilUrl { get; private set; }
    public TipoUsuario TipoUsuario { get; private set; }

    public ICollection<Discussao>? DiscussoesCriadas { get; private set; }
    public ICollection<Resposta>? RespostasCriadas { get; private set; }
    public ICollection<PastaEstudo>? PastasCriadas { get; private set; }
    public ICollection<Arquivo>? ArquivosCriados { get; private set; }
    public ICollection<Mensagem>? MensagensEnviadas { get; private set; }
    public ICollection<Mensagem>? MensagensRecebidas { get; private set; }
    public ICollection<DiscussaoReacao>? ReacoesDiscussao { get; private set; }
    public ICollection<RespostaReacao>? ReacoesResposta { get; private set; }

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
