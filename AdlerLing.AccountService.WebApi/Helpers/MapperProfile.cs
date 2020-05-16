using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.DB.Enitites;
using AdlerLing.AccountService.WebApi.Model.Request;
using AutoMapper;

namespace AdlerLing.AccountService.WebApi.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserModel, UserDTO>()
                .ForMember(d => d.UserId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Email,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.Roles,
                    opt => opt.MapFrom(src => src.Roles))
                .ForMember(d => d.UserInfo,
                    opt => opt.MapFrom(src => src.UserInfo))
                .ReverseMap();

            CreateMap<RoleModel, RoleDTO>()
                .ForMember(d => d.RoleId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<UserInfoModel, UserInfoDTO>()
                .ForMember(d => d.Age,
                    opt => opt.MapFrom(src => src.Age))
                .ForMember(d => d.Gender,
                    opt => opt.MapFrom(src => src.Gender))
                .ReverseMap();
        }
    }
}
