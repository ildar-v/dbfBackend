namespace Volunteer.MainModule.Automapper
{
    using AutoMapper;
    using BLModels.Entities;
    using DTO;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
            .ForMember(lvm => lvm.Uid, opt => opt.MapFrom(vm => vm.Uid))
            .ForMember(lvm => lvm.FullName, opt => opt.MapFrom(vm => vm.FullName))
            .ForMember(lvm => lvm.Login, opt => opt.MapFrom(vm => vm.Login))
            .ForMember(lvm => lvm.PasswordHash, opt => opt.MapFrom(vm => vm.PasswordHash))
            .ForMember(lvm => lvm.Rating, opt => opt.MapFrom(vm => vm.Rating))
            .ForMember(lvm => lvm.AvatarUrl, opt => opt.MapFrom(vm => vm.AvatarUrl))
            .ForMember(lvm => lvm.About, opt => opt.MapFrom(vm => vm.About));

            CreateMap<UserDTO, User>()
            .ForMember(lvm => lvm.Uid, opt => opt.MapFrom(vm => vm.Uid))
            .ForMember(lvm => lvm.FullName, opt => opt.MapFrom(vm => vm.FullName))
            .ForMember(lvm => lvm.Login, opt => opt.MapFrom(vm => vm.Login))
            .ForMember(lvm => lvm.PasswordHash, opt => opt.MapFrom(vm => vm.PasswordHash))
            .ForMember(lvm => lvm.Rating, opt => opt.MapFrom(vm => vm.Rating))
            .ForMember(lvm => lvm.AvatarUrl, opt => opt.MapFrom(vm => vm.AvatarUrl))
            .ForMember(lvm => lvm.About, opt => opt.MapFrom(vm => vm.About));

            CreateMap<Rating, RatingDTO>()
            .ForMember(lvm => lvm.Uid, opt => opt.MapFrom(vm => vm.Uid))
            .ForMember(lvm => lvm.Value, opt => opt.MapFrom(vm => vm.Value));

            CreateMap<RatingDTO, Rating>()
            .ForMember(lvm => lvm.Uid, opt => opt.MapFrom(vm => vm.Uid))
            .ForMember(lvm => lvm.Value, opt => opt.MapFrom(vm => vm.Value));
        }
    }

    public static class AutomapperConfig
    {
        public static MappingProfile GetAutomapperProfile()
        {
            return new MappingProfile();
        }
    }
}
