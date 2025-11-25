using Microsoft.EntityFrameworkCore;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Infrastructure.Context;

namespace UniConnect.Infrastructure.Repository;

public class RespostaRepository : BaseRepository<Resposta>, IRespostaRepository
{
    public RespostaRepository(AppDbContext context) : base(context) { }

    public List<Resposta> GetThreadByDiscussaoId(int discussaoId)
    {
        List<Resposta> todasRespostas = _dbset.Where(r => r.DiscussaoId == discussaoId).Include(x => x.Reacoes).AsNoTracking().ToList();

        var lookup = todasRespostas.ToLookup(c => c.RespostaPaiId);
        foreach (var resposta in todasRespostas)
        {
            if (lookup.Contains(resposta.Id))
                DynamicSetPropertyValue(resposta, "SubRespostas", lookup[resposta.Id].ToList());
        }

        List<Resposta> arvore = todasRespostas.Where(c => c.RespostaPaiId == null).ToList();
        return arvore;
    }
}