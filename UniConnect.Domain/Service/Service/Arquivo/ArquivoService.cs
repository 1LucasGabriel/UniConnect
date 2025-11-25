using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class ArquivoService : BaseService<IArquivoRepository, Arquivo, InputCreateArquivo, InputUpdateArquivo, InputGenericDelete, OutputArquivo>, IArquivoService
{
    private readonly IPastaEstudoRepository _pastaEstudoRepository;

    public ArquivoService(IArquivoRepository repository, IMapper mapper, IPastaEstudoRepository pastaEstudoRepository) : base(repository, mapper)
    {
        _pastaEstudoRepository = pastaEstudoRepository;
    }

    #region Validate
    protected override void OnCreateMultiple(List<InputCreateArquivo>? listInputCreate)
    {
        List<PastaEstudo> listRelatedPastaEstudo = _pastaEstudoRepository.GetListByListId((from i in listInputCreate select i.PastaEstudoId).ToList())!;
        foreach (var i in listInputCreate)
        {
            PastaEstudo? pastaEstudo = (from j in listRelatedPastaEstudo where j.Id == i.PastaEstudoId select j).FirstOrDefault();
            if (pastaEstudo == null)
                throw new Exception($"PastaEstudoId {i.PastaEstudoId} inválido");
        }
    }

    protected override void OnUpdateMultiple(List<InputUpdateArquivo>? listInputUpdate)
    {
        List<PastaEstudo> listRelatedPastaEstudo = _pastaEstudoRepository.GetListByListId((from i in listInputUpdate select i.PastaEstudoId).ToList())!;
        foreach (var i in listInputUpdate)
        {
            PastaEstudo? pastaEstudo = (from j in listRelatedPastaEstudo where j.Id == i.PastaEstudoId select j).FirstOrDefault();
            if (pastaEstudo == null)
                throw new Exception($"PastaEstudoId {i.PastaEstudoId} inválido");
        }
    }
    #endregion

    public List<OutputArquivo> GetArquivosByPastaEstudoId(int pastaEstudoId)
    {
        return Convert(_repository.GetArquivosByPastaEstudoId(pastaEstudoId)) ?? [];
    }
}