using UniConnect.Argument.Enums;

namespace UniConnect.Domain.Entity
{
    public class PastaEstudo : BaseEntity<PastaEstudo>
    {
        public int? PastaEstudoPaiId { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public TipoVisibilidade Visibilidade { get; private set; }

        public PastaEstudo? PastaPai { get; private set; }
        public ICollection<PastaEstudo>? SubPastas { get; private set; }
        public ICollection<Arquivo>? Arquivos { get; private set; }

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
