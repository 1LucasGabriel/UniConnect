using UniConnect.Argument.Enums;

namespace UniConnect.Domain.Entity
{
    public class PastaEstudo : BaseEntity<PastaEstudo>
    {
        public int? PastaEstudoPaiId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public TipoVisibilidade Visibilidade { get; set; }

        public PastaEstudo? PastaPai { get; set; }
        public ICollection<PastaEstudo>? SubPastas { get; set; }
        public ICollection<Arquivo>? Arquivos { get; set; }

        public PastaEstudo() { }

        public PastaEstudo(int? pastaEstudoPaiId, string titulo, string descricao, TipoVisibilidade visibilidade)
        {
            PastaEstudoPaiId = pastaEstudoPaiId;
            Titulo = titulo;
            Descricao = descricao;
            Visibilidade = visibilidade;
        }
    }
}
