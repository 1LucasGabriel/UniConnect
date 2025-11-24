using AutoMapper;
using UniConnect.Argument.Argument;
using UniConnect.Domain.Entity.Entity;

namespace UniConnect.Domain;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User
        CreateMap<Usuario, OutputUsuario>();
        CreateMap<OutputUsuario, Usuario>();
    }
}