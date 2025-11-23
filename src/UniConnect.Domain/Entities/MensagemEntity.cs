using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniConnect.Domain.Entities
{
    public class MensagemEntity: BaseEntity
    {
        public string Conteudo { get; set; }
        public bool Visualizada { get; set; }
        public int UsuarioDestinoId { get; set; }
        public UsuarioEntity UsuarioDestino { get; set; }
    }
}
