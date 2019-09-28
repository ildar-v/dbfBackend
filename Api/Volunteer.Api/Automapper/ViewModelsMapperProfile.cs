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
    using Volunteer.Tags.Models;
    using System.Collections.Generic;

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

            CreateMap<Tag, TagViewModel>()
                .ForMember(t1 => t1.Name, opt => opt.MapFrom(tvm => tvm.Name));
            
            CreateMap<ActivityDetailDTO, ActivityDetailViewModel>()
                .ForMember(lvm => lvm.Uid, opt => opt.MapFrom(vm => vm.Activity.Uid))
                .ForMember(lvm => lvm.Title, opt => opt.MapFrom(vm => vm.Activity.Title))
                .ForMember(lvm => lvm.Description, opt => opt.MapFrom(vm => vm.Activity.Description))
                .ForMember(lvm => lvm.Location, opt => opt.MapFrom(vm => vm.Activity.Location.ToString()))
                .ForMember(lvm => lvm.AddDateTime, opt => opt.MapFrom(vm => vm.Activity.AddDateTime))
                .ForMember(lvm => lvm.Comments, opt => opt.MapFrom(vm => vm.Comments))
                .ForMember(lvm => lvm.Mark, opt => opt.MapFrom(vm => vm.Mark))
                .ForMember(avm => avm.Organizers, opt => opt.MapFrom(dto => dto.Organizers))
                .ForMember(avm => avm.Volunteers, opt => opt.MapFrom(dto => dto.Volunteers))
                .ForMember(avm => avm.Tags, opt => opt.Ignore());
                //.ForMember(avm => avm.Tags, opt => opt.MapFrom(dto => dto.Tags));

            CreateMap<ActivityDTO, ActivityViewModel>()
                .ForMember(lvm => lvm.Uid, opt => opt.MapFrom(vm => vm.Activity.Uid))
                .ForMember(lvm => lvm.Title, opt => opt.MapFrom(vm => vm.Activity.Title))
                .ForMember(lvm => lvm.Description, opt => opt.MapFrom(vm => vm.Activity.Description))
                .ForMember(lvm => lvm.Location, opt => opt.MapFrom(vm => vm.Activity.Location.ToString()))
                .ForMember(lvm => lvm.AddDateTime, opt => opt.MapFrom(vm => vm.Activity.AddDateTime))
                .ForMember(lvm => lvm.Mark, opt => opt.MapFrom(vm => vm.Mark))
                .ForMember(avm => avm.Tags, opt => opt.Ignore());
                //.ForMember(avm => avm.Tags, opt => opt.MapFrom(dto => dto.Tags));

            CreateMap<Comment, CommentViewModel>()
                .ForMember(lvm => lvm.Uid, opt => opt.MapFrom(vm => vm.Uid))
                .ForMember(lvm => lvm.Text, opt => opt.MapFrom(vm => vm.Text))
                .ForMember(lvm => lvm.AuthorUid, opt => opt.MapFrom(vm => vm.AuthorUid))
                .ForMember(lvm => lvm.Author, opt => opt.Ignore())
                .ForMember(lvm => lvm.EntityUid, opt => opt.MapFrom(vm => vm.EntityUid))
                .ForMember(lvm => lvm.Author, opt => opt.Ignore())
                .ForMember(lvm => lvm.AddDateTime, opt => opt.MapFrom(vm => vm.AddDateTime))
                .ForMember(lvm => lvm.Mark, opt => opt.Ignore());

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

            CreateMap<CommentModel, Comment>()
                .ForMember(cdto => cdto.Text, opt => opt.MapFrom(com => com.Text))
                .ForMember(cdto => cdto.AuthorUid, opt => opt.MapFrom(com => com.AuthorUid))
                .ForMember(cdto => cdto.EntityUid, opt => opt.MapFrom(com => com.EntityUid))
                .ForMember(cdto => cdto.Uid, opt => opt.Ignore())
                .ForMember(cdto => cdto.EntityType, opt => opt.Ignore())
                .ForMember(cdto => cdto.AddDateTime, opt => opt.Ignore())
                .ForMember(cdto => cdto.Marks, opt => opt.Ignore());
        }
    }
}
