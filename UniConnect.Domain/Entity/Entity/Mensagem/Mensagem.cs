namespace UniConnect.Domain.Entity
{
    public class Mensagem : BaseEntity<Mensagem>
    {

        public string Conteudo { get; set; }
        public bool Visualizada { get; set; }
        public int UsuarioDestinoId { get; set; }

        public Usuario? UsuarioDestino { get; set; }

        public Mensagem() { }

        public Mensagem(string conteudo, bool visualizada, int usuarioDestinoId)
        {
            Conteudo = conteudo;
            Visualizada = visualizada;
            UsuarioDestinoId = usuarioDestinoId;
        }
    }
}
