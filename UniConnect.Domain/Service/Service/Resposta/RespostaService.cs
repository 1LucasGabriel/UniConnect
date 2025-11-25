using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class RespostaService : BaseService<IRespostaRepository, Resposta, InputCreateResposta, InputUpdateResposta, InputGenericDelete, OutputResposta>, IRespostaService
{
    private readonly IDiscussaoRepository _discussaoRepository;

    public RespostaService(IRespostaRepository repository, IMapper mapper, IDiscussaoRepository discussaoRepository) : base(repository, mapper)
    {
        _discussaoRepository = discussaoRepository;
    }

    #region Validate
    protected override void OnCreateMultiple(List<InputCreateResposta>? listInputCreate)
    {
        List<Discussao> listRelatedDiscussao = _discussaoRepository.GetListByListId((from i in listInputCreate select i.DiscussaoId).ToList())!;
        List<Resposta> listRelatedRespostaPai = _repository.GetListByListId((from i in listInputCreate where i.RespostaPaiId != null select i.RespostaPaiId.Value).ToList())!;
        foreach (var i in listInputCreate)
        {
            Discussao? discussao = (from j in listRelatedDiscussao where j.Id == i.DiscussaoId select j).FirstOrDefault();
            if (discussao == null)
                throw new Exception($"DiscussaoId {i.DiscussaoId} inválido");

            if (i.RespostaPaiId == null)
                continue;

            Resposta? respota = (from j in listRelatedRespostaPai where j.Id == i.RespostaPaiId select j).FirstOrDefault();
            if (respota == null)
                throw new Exception($"RespostaPaiId {i.RespostaPaiId} inválido");
        }
    }

    protected override void OnUpdateMultiple(List<InputUpdateResposta>? listInputUpdate)
    {
        List<Discussao> listRelatedDiscussao = _discussaoRepository.GetListByListId((from i in listInputUpdate select i.DiscussaoId).ToList())!;
        List<Resposta> listRelatedRespostaPai = _repository.GetListByListId((from i in listInputUpdate where i.RespostaPaiId != null select i.RespostaPaiId.Value).ToList())!;

        foreach (var i in listInputUpdate)
        {
            Discussao? discussao = (from j in listRelatedDiscussao where j.Id == i.DiscussaoId select j).FirstOrDefault();
            if (discussao == null)
                throw new Exception($"DiscussaoId {i.DiscussaoId} inválido");

            if (i.RespostaPaiId == null)
                continue;

            Resposta? respota = (from j in listRelatedRespostaPai where j.Id == i.RespostaPaiId select j).FirstOrDefault();
            if (respota == null)
                throw new Exception($"RespostaPaiId {i.RespostaPaiId} inválido");
        }
    }
    #endregion

    public List<OutputResposta> GetThreadByDiscussaoId(int discussaoId)
    {
        return Convert(_repository.GetThreadByDiscussaoId(discussaoId)) ?? [];
    }
}