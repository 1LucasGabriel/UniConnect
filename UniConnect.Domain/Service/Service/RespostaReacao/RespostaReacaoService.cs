using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class RespostaReacaoService : BaseService<IRespostaReacaoRepository, RespostaReacao, InputCreateRespostaReacao, InputUpdateRespostaReacao, InputGenericDelete, OutputRespostaReacao>, IRespostaReacaoService
{
    private readonly IRespostaRepository _respostaRepository;

    public RespostaReacaoService(IRespostaReacaoRepository repository, IMapper mapper, IRespostaRepository respostaRepository) : base(repository, mapper)
    {
        _respostaRepository = respostaRepository;
    }

    #region Validate
    protected override void OnCreateMultiple(List<InputCreateRespostaReacao>? listInputCreate)
    {
        List<Resposta> listRelatedResposta = _respostaRepository.GetListByListId((from i in listInputCreate select i.RespostaId).ToList())!;
        foreach (var i in listInputCreate)
        {
            Resposta? resposta = (from j in listRelatedResposta where j.Id == i.RespostaId select j).FirstOrDefault();
            if (resposta == null)
                throw new Exception($"RespostaId {i.RespostaId} inválido");
        }
    }

    protected override void OnUpdateMultiple(List<InputUpdateRespostaReacao>? listInputUpdate)
    {
        List<Resposta> listRelatedResposta = _respostaRepository.GetListByListId((from i in listInputUpdate select i.RespostaId).ToList())!;
        foreach (var i in listInputUpdate)
        {
            Resposta? resposta = (from j in listRelatedResposta where j.Id == i.RespostaId select j).FirstOrDefault();
            if (resposta == null)
                throw new Exception($"RespostaId {i.RespostaId} inválido");
        }
    }
    #endregion
}