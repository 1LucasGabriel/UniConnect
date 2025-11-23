using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniConnect.Domain.Entities
{
    public class ArquivoEntity: BaseEntity
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Url { get; set; }
        public long TamanhoBytes { get; set; }
        public int PastaEstudoId { get; set; }
        public PastaEstudoEntity PastaEstudo { get; set; }
    }
}
