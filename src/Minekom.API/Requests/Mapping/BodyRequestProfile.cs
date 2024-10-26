using AutoMapper;
using Minekom.BackOfficeAPI.Requests;
using Minekom.Domain.Bo;

namespace Minekom.API.Requests.Mapping
{
    /// <summary>
    /// Mapper profile for requests to bo objects
    /// </summary>
    public class BodyRequestProfile : Profile
    {
        /// <summary>
        /// ctor containing mapping definition
        /// </summary>
        public BodyRequestProfile()
        {
            CreateMap<RegisterRequest, Utilisateur>()
                .ForMember(p_Dest => p_Dest.Id, p_Opt => p_Opt.Ignore())
                .ForMember(p_Dest => p_Dest.Nom, p_Opt => p_Opt.MapFrom(p_Src => p_Src.LastName))
                .ForMember(p_Dest => p_Dest.Prenom, p_Opt => p_Opt.MapFrom(p_Src => p_Src.FirstName))
                .ForMember(p_Dest => p_Dest.Email, p_Opt => p_Opt.MapFrom(p_Src => p_Src.Email))
                .ForMember(p_Dest => p_Dest.MotDePasse, p_Opt => p_Opt.MapFrom(p_Src => p_Src.Password));

        }
    }
}