using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniConnect.Domain.Entities
{
    public class RespostaEntity: BaseEntity
    {
        public int DiscussaoId { get; set; }
        public DiscussaoEntity Discussao { get; set; }
        public int? RespostaPaiId { get; set; }
        public RespostaEntity RespostaPai { get; set; }
        public ICollection<RespostaEntity> SubRespostas { get; set; }
        public string Conteudo { get; set; }
        public ICollection<RespostaReacaoEntity> Reacoes { get; set; }
    }
}
