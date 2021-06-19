using AutoMapper;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Application.DTOs;

namespace CCN_Solution.ColisDDD.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Agence, AgenceDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Colis, ColisDto>().ReverseMap();
            CreateMap<Images, ImagesDto>().ReverseMap();
            CreateMap<Livraison, LivraisonDto>().ReverseMap();
            CreateMap<PrixVoyageRegion, PrixVoyageRegionDto>().ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<TypeDeColis, TypeDeColisDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<TypeAgence, TypeAgenceDto>().ReverseMap();
            CreateMap<TypeLivraison, TypeLivraisonDto>().ReverseMap();
            CreateMap<MoyenTransport, MoyenTransportDto>().ReverseMap();
        }
    }
}
