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
    using Api.Models;
    using Authentity.Model;
    using Volunteer.Comments;

    public class ViewModelsMapperProfile : Profile
    {
        public ViewModelsMapperProfile()
        {
            CreateMap<RatingDTO, RatingViewModel>()
            .ForMember(lvm => lvm.Uid, opt => opt.MapFrom(vm => vm.Uid))
            .ForMember(lvm => lvm.Value, opt => opt.MapFrom(vm => vm.Value));

            CreateMap<UserDTO, UserViewModel>()
            .ForMember(lvm => lvm.Uid, opt => opt.MapFrom(vm => vm.Uid))
            .ForMember(lvm => lvm.FullName, opt => opt.MapFrom(vm => vm.FullName))
            .ForMember(lvm => lvm.Rating, opt => opt.MapFrom(vm => vm.Rating))
            .ForMember(lvm => lvm.AvatarUrl, opt => opt.MapFrom(vm => vm.AvatarUrl))
            .ForMember(lvm => lvm.About, opt => opt.MapFrom(vm => vm.About));

            CreateMap<ActivityDTO, ActivityViewModel>()
            .ForMember(avm => avm.Uid, opt => opt.MapFrom(dto => dto.Activity.Uid))
            .ForMember(avm => avm.Title, opt => opt.MapFrom(dto => dto.Activity.Title))
            .ForMember(avm => avm.Description, opt => opt.MapFrom(dto => dto.Activity.Description))
            .ForMember(avm => avm.Location, opt => opt.MapFrom(dto => dto.Activity.Location.ToString()))
            .ForMember(avm => avm.AddDateTime, opt => opt.MapFrom(dto => dto.Activity.AddDateTime))
            .ForMember(avm => avm.CommentCount, opt => opt.MapFrom(dto => dto.Comments.Count()))
            .ForMember(avm => avm.Tags, opt => opt.MapFrom(dto => dto.Tags))
            .ForMember(avm => avm.Mark, opt => opt.MapFrom(dto => dto.Mark));

            CreateMap<ActivityDTO, ActivityDetailViewModel>()
            .ForMember(lvm => lvm.Uid, opt => opt.MapFrom(vm => vm.Activity.Uid))
            .ForMember(lvm => lvm.Title, opt => opt.MapFrom(vm => vm.Activity.Title))
            .ForMember(lvm => lvm.Description, opt => opt.MapFrom(vm => vm.Activity.Description))
            .ForMember(lvm => lvm.Location, opt => opt.MapFrom(vm => vm.Activity.Location.ToString()))
            .ForMember(lvm => lvm.AddDateTime, opt => opt.MapFrom(vm => vm.Activity.AddDateTime))
            .ForMember(lvm => lvm.Comments, opt => opt.MapFrom(vm => vm.Comments))
            .ForMember(lvm => lvm.Mark, opt => opt.MapFrom(vm => vm.Mark))
            .ForMember(avm => avm.Organizers, opt => opt.MapFrom(dto => dto.Organizers))
            .ForMember(avm => avm.Volunteers, opt => opt.MapFrom(dto => dto.Volunteers));

            CreateMap<Comment, CommentViewModel>()
            .ForMember(lvm => lvm.Text, opt => opt.MapFrom(vm => vm.Text))
            .ForMember(lvm => lvm.AuthorUid, opt => opt.MapFrom(vm => vm.AuthorUid))
            .ForMember(lvm => lvm.AddDateTime, opt => opt.MapFrom(vm => vm.AddDateTime));

            CreateMap<ActivityCreateModel, ActivityCreateDTO>()
            .ForMember(lvm => lvm.Title, opt => opt.MapFrom(vm => vm.Title))
            .ForMember(lvm => lvm.Description, opt => opt.MapFrom(vm => vm.Description))
            .ForMember(lvm => lvm.ImageUrl, opt => opt.MapFrom(vm => vm.ImageUrl))
            .ForMember(lvm => lvm.AuthorUids, opt => opt.MapFrom(vm => vm.AuthorUids));

            CreateMap<Comment, CommentDTO>()
                .ForMember(cdto => cdto.Uid, opt => opt.MapFrom(com => com.Uid))
                .ForMember(cdto => cdto.Text, opt => opt.MapFrom(com => com.Text))
                .ForMember(cdto => cdto.AuthorUid, opt => opt.MapFrom(com => com.AuthorUid))
                .ForMember(cdto => cdto.EntityUid, opt => opt.MapFrom(com => com.EntityUid))
                .ForMember(cdto => cdto.EntityType, opt => opt.MapFrom(com => com.EntityType))
                .ForMember(cdto => cdto.AddDateTime, opt => opt.MapFrom(com => com.AddDateTime))
                .ForMember(cdto => cdto.Author, opt => opt.Ignore())
                .ForMember(cdto => cdto.Mark, opt => opt.Ignore());

            CreateMap<CommentDTO, CommentViewModel>()
                .ForMember(cdto => cdto.Uid, opt => opt.MapFrom(com => com.Uid))
                .ForMember(cdto => cdto.Text, opt => opt.MapFrom(com => com.Text))
                .ForMember(cdto => cdto.AuthorUid, opt => opt.MapFrom(com => com.AuthorUid))
                .ForMember(cdto => cdto.Author, opt => opt.MapFrom(com => com.Author))
                .ForMember(cdto => cdto.EntityUid, opt => opt.MapFrom(com => com.EntityUid))
                .ForMember(cdto => cdto.AddDateTime, opt => opt.MapFrom(com => com.AddDateTime))
                .ForMember(cdto => cdto.Mark, opt => opt.MapFrom(com => com.Mark));
        }
    }
}
