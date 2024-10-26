using AutoMapper;
using Bo = Minekom.Domain.Bo;
using Ef = Minekom.Infrastructure.Data.EntityFramework.Entities;

namespace Minekom.Infrastructure.Data.Mapping;

internal class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Ef.Antenne, Bo.Antenne>().PreserveReferences().ReverseMap();
        CreateMap<Ef.Utilisateur, Bo.Utilisateur>().PreserveReferences().ReverseMap();
    }
}