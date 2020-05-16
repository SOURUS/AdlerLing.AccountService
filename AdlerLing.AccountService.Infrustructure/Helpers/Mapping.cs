using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.DB.Enitites;
using AutoMapper;
using System;

namespace AdlerLing.AccountService.Infrustructure.Helpers
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>()
                .ForMember(d => d.user_id,
                    opt => opt.MapFrom(src => src.UserId))
                .ForMember(d => d.email,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.roles,
                    opt => opt.MapFrom(src => src.Roles))
                .ForMember(d => d.password,
                    opt => opt.MapFrom(src => src.Password))
                .ForMember(d => d.user_info,
                    opt => opt.MapFrom(src => src.UserInfo))
                .ReverseMap();

            CreateMap<RoleDTO, Role>()
                .ForMember(d => d.role_id,
                    opt => opt.MapFrom(src => src.RoleId))
                .ForMember(d => d.name,
                    opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<UserInfoDTO, UserInfo>()
                .ForMember(d => d.user_id,
                    opt => opt.MapFrom(src => src.UserId))
                .ForMember(d => d.age,
                    opt => opt.MapFrom(src => src.Age))
                .ForMember(d => d.gender,
                    opt => opt.MapFrom(src => src.Gender))
                .ReverseMap();

            CreateMap<GetUserDTO, User>()
                .ForMember(d => d.user_id,
                    opt => opt.MapFrom(src => src.UserId))
                .ForMember(d => d.email,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.roles,
                    opt => opt.MapFrom(src => src.Roles))
                .ForMember(d => d.user_info,
                    opt => opt.MapFrom(src => src.UserInfo))
                .ReverseMap();
        }
    }
}
