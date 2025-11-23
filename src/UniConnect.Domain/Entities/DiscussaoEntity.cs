using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniConnect.Domain.Entities
{
    public class DiscussaoEntity: BaseEntity
    {
        public int? DiscussaoPaiId { get; set; }
        public DiscussaoEntity DiscussaoPai { get; set; }
        public ICollection<DiscussaoEntity> SubDiscussoes { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public ICollection<RespostaEntity> Respostas { get; set; }
        public ICollection<DiscussaoReacaoEntity> Reacoes { get; set; }
    }
}
