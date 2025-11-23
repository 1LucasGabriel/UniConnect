using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniConnect.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int UsuarioCriacaoId { get; set; }
        public UsuarioEntity UsuarioCriacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? UsuarioAlteracaoId { get; set; }
        public UsuarioEntity UsuarioAlteracao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
