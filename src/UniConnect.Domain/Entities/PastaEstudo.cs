using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniConnect.Domain.Enums;

namespace UniConnect.Domain.Entities
{
    public class PastaEstudo: BaseEntity
    {
        public int PastaEstudoPaiId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public TipoVisibilidade Visibilidade { get; set; }
        public ICollection<ArquivoEntity> Arquivos { get; set; }
    }
}
