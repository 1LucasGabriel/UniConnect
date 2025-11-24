namespace UniConnect.Domain.Entity
{
    public class Arquivo : BaseEntity<Arquivo>
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Url { get; set; }
        public long TamanhoBytes { get; set; }
        public int PastaEstudoId { get; set; }

        public PastaEstudo PastaEstudo { get; set; }

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
