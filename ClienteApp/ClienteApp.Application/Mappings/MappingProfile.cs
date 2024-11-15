using AutoMapper;
using ClienteApp.Domain.Cliente.Dto;
using ClienteApp.Domain.Cliente.Request;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ClienteRequest, Clientes>();
    }
}
