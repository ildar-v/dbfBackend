namespace Volunteer.Api.Automapper
{
    using System.Linq;
    using AutoMapper;
    using Api.ViewModels;
    using DTO;
    using Api.ViewModels.Activity;
    using Activities.DTO;
    using Comments.Entity;
    using Api.ViewModels.Comment;
    using BLModels.Interfaces;
    using Volunteer.Api.Models;

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

            CreateMap<ActivityDTO, ActivityViewModel>()
            .ForMember(lvm => lvm.Uid, opt => opt.MapFrom(vm => vm.Activity.Uid))
            .ForMember(lvm => lvm.Title, opt => opt.MapFrom(vm => vm.Activity.Title))
            .ForMember(lvm => lvm.Description, opt => opt.MapFrom(vm => vm.Activity.Description))
            .ForMember(lvm => lvm.Location, opt => opt.MapFrom(vm => vm.Activity.Location.ToString()))
            .ForMember(lvm => lvm.AddDateTime, opt => opt.MapFrom(vm => vm.Activity.AddDateTime))
            .ForMember(lvm => lvm.CommentCount, opt => opt.MapFrom(vm => vm.Comments.Count()))
            .ForMember(lvm => lvm.Mark, opt => opt.MapFrom(vm => vm.Mark));

            CreateMap<ActivityDTO, ActivityDetailViewModel>()
            .ForMember(lvm => lvm.Uid, opt => opt.MapFrom(vm => vm.Activity.Uid))
            .ForMember(lvm => lvm.Title, opt => opt.MapFrom(vm => vm.Activity.Title))
            .ForMember(lvm => lvm.Description, opt => opt.MapFrom(vm => vm.Activity.Description))
            .ForMember(lvm => lvm.Location, opt => opt.MapFrom(vm => vm.Activity.Location.ToString()))
            .ForMember(lvm => lvm.AddDateTime, opt => opt.MapFrom(vm => vm.Activity.AddDateTime))
            .ForMember(lvm => lvm.Comments, opt => opt.MapFrom(vm => vm.Comments));

            CreateMap<Comment, CommentViewModel>()
            .ForMember(lvm => lvm.Text, opt => opt.MapFrom(vm => vm.Text))
            .ForMember(lvm => lvm.AuthorUid, opt => opt.MapFrom(vm => vm.AuthorUid))
            .ForMember(lvm => lvm.Parent, opt => opt.MapFrom(vm => vm.Parent))
            .ForMember(lvm => lvm.AddDateTime, opt => opt.MapFrom(vm => vm.AddDateTime));

            CreateMap<ActivityCreateModel, ActivityCreateDTO>()
            .ForMember(lvm => lvm.Title, opt => opt.MapFrom(vm => vm.Title))
            .ForMember(lvm => lvm.Description, opt => opt.MapFrom(vm => vm.Description))
            .ForMember(lvm => lvm.ImageUrl, opt => opt.MapFrom(vm => vm.ImageUrl))
            .ForMember(lvm => lvm.AuthorUids, opt => opt.MapFrom(vm => vm.AuthorUids));
        }
    }
}
