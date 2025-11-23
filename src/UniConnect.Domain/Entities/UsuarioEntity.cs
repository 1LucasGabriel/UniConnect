using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniConnect.Domain.Enums;

namespace UniConnect.Domain.Entities
{
    public class UsuarioEntity: BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string FotoPerfilUrl { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        // Navegações
        public ICollection<DiscussaoEntity> DiscussoesCriadas { get; set; }
        public ICollection<RespostaEntity> RespostasCriadas { get; set; }
        public ICollection<PastaEstudoEntity> PastasCriadas { get; set; }
        public ICollection<ArquivoEntity> ArquivosCriados { get; set; }

        public ICollection<MensagemEntity> MensagensEnviadas { get; set; }
        public ICollection<MensagemEntity> MensagensRecebidas { get; set; }

        public ICollection<DiscussaoReacaoEntity> ReacoesDiscussao { get; set; }
        public ICollection<RespostaReacaoEntity> ReacoesResposta { get; set; }
    }
}
