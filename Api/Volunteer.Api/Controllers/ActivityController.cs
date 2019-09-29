namespace Volunteer.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;
    using Activities.Interactor;
    using Activities.DTO;
    using Api.ViewModels.Activity;
    using Api.Models;
    using MainModule.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Volunteer.Comments.Entity;
    using Volunteer.MainModule.Managers;
    using Volunteer.Api.ViewModels.Comment;
    using Volunteer.MainModule.Managers.Filters;
    using Volunteer.Api.ViewModels;
    using Volunteer.BLModels.Entities;
    using Volunteer.DTO;

    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ActivitiesInteractor activitiesInteractor;
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly ISimpleManager<Comment> commentSimpleManager;
        private readonly IActivitiesUsersService activitiesUsersService;
        private readonly IMarkService markService;

        public ActivityController(ActivitiesInteractor activitiesInteractor, IUserService userService,
            IMapper mapper, ISimpleManager<Comment> commentSimpleManager, IMarkService markService, IActivitiesUsersService activitiesUsersService)
        {
            this.activitiesInteractor = activitiesInteractor;
            this.mapper = mapper;
            this.userService = userService;
            this.commentSimpleManager = commentSimpleManager;
            this.markService = markService;
            this.activitiesUsersService = activitiesUsersService;
        }

        [HttpGet("api/activity")]
        public IActionResult GetAll()
        {
            var data = this.activitiesInteractor.Find();

            if (data != null)
            {
                var activitiesUsersList = this.activitiesUsersService.Find();
                var result = mapper.Map<IEnumerable<ActivityViewModel>>(data);

                foreach (var item in result)
                {
                    ActivitiesUsers activitiesUsers = activitiesUsersList.FirstOrDefault(au =>
                                                                au.ActivityGuid == item.Uid 
                                                                && au.UserType == BLModels.Enums.UserTypes.Organizer);

                    if (activitiesUsers == null)
                        continue;

                    UserDTO user = this.userService.FindByUid(activitiesUsers.UserGuid);
                    item.AuthorUid = activitiesUsers.UserGuid;
                    item.AuthorFullName = user.FullName;
                    item.AuthorAvatar = user.AvatarUrl;
                }

                return Ok(result);
            }

            return new NotFoundResult();
        }

        [HttpGet("api/activity/{id}")]
        public ActionResult<ActivityDetailViewModel> Get(Guid id)
        {
            var dto = this.activitiesInteractor.FindScalarByUid(id);

            if (dto != null)
            {
                var result = mapper.Map<ActivityDetailViewModel>(dto);
                return Ok(result);
            }

            return new NotFoundResult();
        }

        [HttpPost("api/activity")]
        public ActionResult<ActivityDetailViewModel> Post([FromBody]ActivityCreateModel activityModel)
        {
            var newActivity = mapper.Map<ActivityCreateDTO>(activityModel);
            string login = string.Empty;

            foreach (var item in User.Claims)
            {
                if (item.Type == "Login")
                {
                    login = item.Value;
                    break;
                }
            }

            var currentUser = this.userService.FindByLogin(login);

            if (currentUser != null)
            {
                if (newActivity.AuthorUids == null)
                {
                    newActivity.AuthorUids = new List<Guid>();
                }

                newActivity.AuthorUids.Add(currentUser.Uid);

                if (this.activitiesInteractor.Save(newActivity))
                {
                    return Ok(new { success = "Мероприятие создано" });
                }
            }

            return StatusCode(403);
        }

        [HttpPost("api/activity/comment")]
        public ActionResult<IEnumerable<CommentViewModel>> Post([FromBody] CommentModel commentModel)
        {
            var comment = mapper.Map<Comment>(commentModel);
            comment.EntityType = typeof(Activity);
            this.commentSimpleManager.Save(comment);
            var comments = this.commentSimpleManager
                .Find(
                    new Filter(nameof(Comment.EntityUid),
                    new object[] { commentModel.EntityUid }
                ));
            var commentVMs = mapper.Map<IEnumerable<CommentViewModel>>(comments);
            foreach (var commentVM in commentVMs)
            {
                commentVM.Mark = this.markService.GetRaiting(commentModel.EntityUid);
                var userDTO = this.userService.FindByUid(commentModel.AuthorUid);
                commentVM.Author = mapper.Map<UserViewModel>(userDTO);
            }
            return Ok(commentVMs);
        }
    }
}
