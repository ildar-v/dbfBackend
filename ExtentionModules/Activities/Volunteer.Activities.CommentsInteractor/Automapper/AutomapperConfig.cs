namespace Volunteer.Activities.Interactor
{
    using AutoMapper;
    using BLModels.Entities;
    using DTO;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ActivityCreateDTO, Activity>()
            .ForMember(lvm => lvm.Title, opt => opt.MapFrom(vm => vm.Title))
            .ForMember(lvm => lvm.Description, opt => opt.MapFrom(vm => vm.Description))
            .ForMember(lvm => lvm.ImageUrl, opt => opt.MapFrom(vm => vm.ImageUrl));
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
