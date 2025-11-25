using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class DiscussaoService : BaseService<IDiscussaoRepository, Discussao, InputCreateDiscussao, InputUpdateDiscussao, InputGenericDelete, OutputDiscussao>, IDiscussaoService
{
    public DiscussaoService(IDiscussaoRepository repository, IMapper mapper) : base(repository, mapper) { }

    #region Validate
    protected override void OnCreateMultiple(List<InputCreateDiscussao>? listInputCreate)
    {
        List<Discussao> listRelatedDiscussaoPai = _repository.GetListByListId((from i in listInputCreate where i.DiscussaoPaiId != null select i.DiscussaoPaiId!.Value).ToList())!;
        foreach (var i in listInputCreate)
        {
            if (i.DiscussaoPaiId == null)
                continue;

            Discussao? discussao = (from j in listRelatedDiscussaoPai where j.Id == i.DiscussaoPaiId select j).FirstOrDefault();
            if (discussao == null)
                throw new Exception($"DiscussaoPaiId {i.DiscussaoPaiId} inválido");
        }
    }

    protected override void OnUpdateMultiple(List<InputUpdateDiscussao>? listInputUpdate)
    {
        List<Discussao> listRelatedDiscussaoPai = _repository.GetListByListId((from i in listInputUpdate where i.DiscussaoPaiId != null select i.DiscussaoPaiId!.Value).ToList())!;
        foreach (var i in listInputUpdate)
        {
            if (i.DiscussaoPaiId == null)
                continue;

            Discussao? discussao = (from j in listRelatedDiscussaoPai where j.Id == i.DiscussaoPaiId select j).FirstOrDefault();
            if (discussao == null)
                throw new Exception($"DiscussaoPaiId {i.DiscussaoPaiId} inválido");
        }
    }
    #endregion
}