using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniConnect.Domain.Enums;

namespace UniConnect.Application.DTOs
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string FotoPerfilUrl { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
