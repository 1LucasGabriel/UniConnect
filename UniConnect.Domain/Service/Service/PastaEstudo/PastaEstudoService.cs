using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class PastaEstudoService : BaseService<IPastaEstudoRepository, PastaEstudo, InputCreatePastaEstudo, InputUpdatePastaEstudo, InputGenericDelete, OutputPastaEstudo>, IPastaEstudoService
{
    public PastaEstudoService(IPastaEstudoRepository repository, IMapper mapper) : base(repository, mapper) { }

    #region Validate
    protected override void OnCreateMultiple(List<InputCreatePastaEstudo>? listInputCreate)
    {
        List<PastaEstudo> listRelatedPastaEstudo = _repository.GetListByListId((from i in listInputCreate where i.PastaEstudoPaiId != null select i.PastaEstudoPaiId!.Value).ToList())!;
        foreach (var i in listInputCreate)
        {
            if (i.PastaEstudoPaiId == null)
                continue;

            PastaEstudo? pastaEstudo = (from j in listRelatedPastaEstudo where j.Id == i.PastaEstudoPaiId select j).FirstOrDefault();
            if (pastaEstudo == null)
                throw new Exception($"PastaEstudoId {i.PastaEstudoPaiId} inválido");
        }
    }

    protected override void OnUpdateMultiple(List<InputUpdatePastaEstudo>? listInputUpdate)
    {
        List<PastaEstudo> listRelatedPastaEstudo = _repository.GetListByListId((from i in listInputUpdate where i.PastaEstudoPaiId != null select i.PastaEstudoPaiId!.Value).ToList())!;
        foreach (var i in listInputUpdate)
        {
            if (i.PastaEstudoPaiId == null)
                continue;

            PastaEstudo? pastaEstudo = (from j in listRelatedPastaEstudo where j.Id == i.PastaEstudoPaiId select j).FirstOrDefault();
            if (pastaEstudo == null)
                throw new Exception($"PastaEstudoId {i.PastaEstudoPaiId} inválido");
        }
    }
    #endregion
}