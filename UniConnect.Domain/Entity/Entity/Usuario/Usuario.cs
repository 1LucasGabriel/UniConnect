using UniConnect.Argument.Enums;

namespace UniConnect.Domain.Entity;

public class Usuario : BaseEntity<Usuario>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Senha { get; set; }
    public string FotoPerfilUrl { get; set; }
    public TipoUsuario TipoUsuario { get; set; }

    public ICollection<Discussao>? DiscussoesCriadas { get; set; }
    public ICollection<Resposta>? RespostasCriadas { get; set; }
    public ICollection<PastaEstudo>? PastasCriadas { get; set; }
    public ICollection<Arquivo>? ArquivosCriados { get; set; }
    public ICollection<Mensagem>? MensagensEnviadas { get; set; }
    public ICollection<Mensagem>? MensagensRecebidas { get; set; }
    public ICollection<DiscussaoReacao>? ReacoesDiscussao { get; set; }
    public ICollection<RespostaReacao>? ReacoesResposta { get; set; }

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
