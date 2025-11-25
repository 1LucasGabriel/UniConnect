namespace UniConnect.Domain.Entity
{
    public class Mensagem : BaseEntity<Mensagem>
    {

        public string Conteudo { get; private set; }
        public bool Visualizada { get; private set; }
        public int UsuarioDestinoId { get; private set; }

        public Usuario? UsuarioDestino { get; private set; }

        public Mensagem() { }

        public Mensagem(string conteudo, bool visualizada, int usuarioDestinoId)
        {
            Conteudo = conteudo;
            Visualizada = visualizada;
            UsuarioDestinoId = usuarioDestinoId;
        }
    }
}
