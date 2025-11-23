using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniConnect.Domain.Entities
{
    public class RespostaEntity: BaseEntity
    {
        public int RespostaPaiId { get; set; }
        public string Conteudo { get; set; }
        public int DiscussaoId { get; set; }
        public ICollection<RespostaReacaoEntity> Reacoes { get; set; }
    }
}
