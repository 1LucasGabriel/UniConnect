using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Argument.Base;
using UniConnect.Domain.Entity;
using UniConnect.Domain.Interface.Repository.Repository;
using UniConnect.Domain.Interface.Service;

namespace UniConnect.Domain.Service;

public class MensagemService : BaseService<IMensagemRepository, Mensagem, InputCreateMensagem, InputUpdateMensagem, InputGenericDelete, OutputMensagem>, IMensagemService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public MensagemService(IMensagemRepository repository, IMapper mapper, IUsuarioRepository usuarioRepository) : base(repository, mapper)
    {
        _usuarioRepository = usuarioRepository;
    }

    #region Validate
    protected override void OnCreateMultiple(List<InputCreateMensagem>? listInputCreate)
    {
        List<Usuario> listRelatedUsuario = _usuarioRepository.GetListByListId((from i in listInputCreate select i.UsuarioDestinoId).ToList())!;
        foreach (var i in listInputCreate)
        {
            Usuario? usuario = (from j in listRelatedUsuario where j.Id == i.UsuarioDestinoId select j).FirstOrDefault();
            if (usuario == null)
                throw new Exception($"UsuarioDestinoId {i.UsuarioDestinoId} inválido");
        }
    }

    protected override void OnUpdateMultiple(List<InputUpdateMensagem>? listInputUpdate)
    {
        List<Usuario> listRelatedUsuario = _usuarioRepository.GetListByListId((from i in listInputUpdate select i.UsuarioDestinoId).ToList())!;
        foreach (var i in listInputUpdate)
        {
            Usuario? usuario = (from j in listRelatedUsuario where j.Id == i.UsuarioDestinoId select j).FirstOrDefault();
            if (usuario == null)
                throw new Exception($"UsuarioDestinoId {i.UsuarioDestinoId} inválido");
        }
    }
    #endregion

    public List<OutputMensagem> GetConversaByUsuarioId(int usuarioDestinoId)
    {
        return Convert(_repository.GetConversaByUsuarioId(usuarioDestinoId)) ?? [];
    }
}