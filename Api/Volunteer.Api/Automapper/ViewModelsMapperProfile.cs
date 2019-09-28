namespace Volunteer.Api.Automapper
{
    using AutoMapper;
    using Api.ViewModels;
    using DTO;

    public class ViewModelsMapperProfile : Profile
    {
        public ViewModelsMapperProfile()
        {
            CreateMap<RatingDTO, RatingViewModel>()
            .ForMember(lvm => lvm.Uid, opt => opt.MapFrom(vm => vm.Uid))
            .ForMember(lvm => lvm.Value, opt => opt.MapFrom(vm => vm.Value));
            CreateMap<UserDTO, UserListViewModel>()
            .ForMember(lvm => lvm.Uid, opt => opt.MapFrom(vm => vm.Uid))
            .ForMember(lvm => lvm.FullName, opt => opt.MapFrom(vm => vm.FullName))
            .ForMember(lvm => lvm.Rating, opt => opt.MapFrom(vm => vm.Rating))
            .ForMember(lvm => lvm.AvatarUrl, opt => opt.MapFrom(vm => vm.AvatarUrl))
            .ForMember(lvm => lvm.About, opt => opt.MapFrom(vm => vm.About));
        }
    }
}
