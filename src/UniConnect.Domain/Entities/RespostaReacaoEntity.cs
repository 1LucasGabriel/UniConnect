using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniConnect.Domain.Enums;

namespace UniConnect.Domain.Entities
{
    public class RespostaReacaoEntity: BaseEntity
    {
        public int RespostaId { get; set; }
        public TipoReacao Tipo { get; set; }
    }
}
