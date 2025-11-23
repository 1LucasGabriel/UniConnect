using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniConnect.Domain.Enums;

namespace UniConnect.Domain.Entities
{
    public class DiscussaoReacaoEntity: BaseEntity
    {
        public int DiscussaoId { get; set; }
        public DiscussaoEntity Discussao { get; set; }
        public TipoReacao Tipo { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioEntity Usuario { get; set; }
    }
}
