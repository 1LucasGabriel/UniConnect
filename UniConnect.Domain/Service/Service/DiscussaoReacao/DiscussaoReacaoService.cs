using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class DiscussaoReacaoService : BaseService<IDiscussaoReacaoRepository, DiscussaoReacao, InputCreateDiscussaoReacao, InputUpdateDiscussaoReacao, InputGenericDelete, OutputDiscussaoReacao>, IDiscussaoReacaoService
{
    private readonly IDiscussaoRepository _discussaoRepository;

    public DiscussaoReacaoService(IDiscussaoReacaoRepository repository, IMapper mapper, IDiscussaoRepository discussaoRepository) : base(repository, mapper)
    {
        _discussaoRepository = discussaoRepository;
    }

    #region Validate
    protected override void OnCreateMultiple(List<InputCreateDiscussaoReacao>? listInputCreate)
    {
        List<Discussao> listRelatedDiscussao = _discussaoRepository.GetListByListId((from i in listInputCreate select i.DiscussaoId).ToList())!;
        foreach (var i in listInputCreate)
        {
            Discussao? discussao = (from j in listRelatedDiscussao where j.Id == i.DiscussaoId select j).FirstOrDefault();
            if (discussao == null)
                throw new Exception($"DiscussaoId {i.DiscussaoId} inválido");
        }
    }

    protected override void OnUpdateMultiple(List<InputUpdateDiscussaoReacao>? listInputUpdate)
    {
        List<Discussao> listRelatedDiscussao = _discussaoRepository.GetListByListId((from i in listInputUpdate select i.DiscussaoId).ToList())!;
        foreach (var i in listInputUpdate)
        {
            Discussao? discussao = (from j in listRelatedDiscussao where j.Id == i.DiscussaoId select j).FirstOrDefault();
            if (discussao == null)
                throw new Exception($"DiscussaoId {i.DiscussaoId} inválido");
        }
    }
    #endregion
}