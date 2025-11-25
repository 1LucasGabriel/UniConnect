namespace UniConnect.Domain.Entity
{
    public class Arquivo : BaseEntity<Arquivo>
    {
        public string Nome { get; private set; }
        public string Tipo { get; private set; }
        public string Url { get; private set; }
        public long TamanhoBytes { get; private set; }
        public int PastaEstudoId { get; private set; }

        public PastaEstudo PastaEstudo { get; private set; }

        public Arquivo() { }

        public Arquivo(string nome, string tipo, string url, long tamanhoBytes, int pastaEstudoId, PastaEstudo pastaEstudo)
        {
            Nome = nome;
            Tipo = tipo;
            Url = url;
            TamanhoBytes = tamanhoBytes;
            PastaEstudoId = pastaEstudoId;
            PastaEstudo = pastaEstudo;
        }
    }
}
