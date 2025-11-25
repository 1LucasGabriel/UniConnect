using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Domain.Entity;

namespace UniConnect.Domain;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Usuario, OutputUsuario>();
        CreateMap<OutputUsuario, Usuario>();

        CreateMap<PastaEstudo, OutputPastaEstudo>();
        CreateMap<OutputPastaEstudo, PastaEstudo>();

        CreateMap<Arquivo, OutputArquivo>();
        CreateMap<OutputArquivo, Arquivo>();

        CreateMap<Discussao, OutputDiscussao>();
        CreateMap<OutputDiscussao, Discussao>();

        CreateMap<Resposta, OutputResposta>();
        CreateMap<OutputResposta, Resposta>();

        CreateMap<DiscussaoReacao, OutputDiscussaoReacao>();
        CreateMap<OutputDiscussaoReacao, DiscussaoReacao>();

        CreateMap<RespostaReacao, OutputRespostaReacao>();
        CreateMap<OutputRespostaReacao, RespostaReacao>();

        CreateMap<Mensagem, OutputMensagem>();
        CreateMap<OutputMensagem, Mensagem>();
    }
}