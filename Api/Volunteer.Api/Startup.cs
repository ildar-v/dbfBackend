﻿namespace Volunteer.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;
    using TempDAL;
    using Activities.Interactor;
    using BLModels.Entities;
    using Comments.DataManager;
    using Comments.Entity;
    using Comments.Manager;
    using DirtyData;
    using MainModule.Managers;
    using MainModule.Managers.DataManagers;
    using MainModule.Managers.Implementations;
    using MainModule.Services.Interfaces;
    using MainModule.Services.Implementations;
    using AutoMapper;
    using System.Collections.Generic;
    using Api.Automapper;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using Volunteer.Authentity;
    using Volunteer.Tags.Managers;
    using Finances.Services.CashFlowService;
    using Finances.Managers;
    using Finances.Models;
    using TempDAL.FinanceSystemDAL;
    using Volunteer.Finances.Services.FundsService;
    using Volunteer.Finances;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "My API", Version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = "Volunteer",
                            ValidateAudience = true,
                            ValidAudience = "Client",
                            ValidateLifetime = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("somethink_secret_key")),
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IDataManager<Activity>, ActivityDataManager>();
            services.AddTransient<ISimpleManager<Activity>, ActivityManager>();
            services.AddTransient<IDataManager<Comment>, CommentDataManager>();
            services.AddTransient<ISimpleManager<Comment>, CommentsManager>();
            services.AddTransient<IDataManager<Mark>, MarkDataManager>();
            services.AddTransient<ISimpleManager<Mark>, MarkManager>();
            services.AddTransient<IMarkService, MarkService>();
            services.AddTransient<ISimpleManager<User>, UserManager>();
            services.AddTransient<IDataManager<User>, UserDataManager>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDataManager<ActivitiesUsers>, ActivitiesUsersDataManager>();
            services.AddTransient<ISimpleManager<ActivitiesUsers>, ActivitiesUsersManager>();
            services.AddTransient<IDataManager<Tags.Models.Tag>, TagsDataManager>();
            services.AddTransient<ISimpleManager<Tags.Models.Tag>, TagManager>();

            services.AddTransient<ActivitiesInteractor>();
            services.AddTransient<Authentification>();
            services.AddTransient<ICashFlowService, CashFlowService>();
            services.AddTransient<ISimpleManager<CashFlow>, CashFlowManager>();
            services.AddTransient<IDataManager<CashFlow>, CashFlowDataManager>();
            services.AddTransient<IFundsService, FundsService>(); 
            services.AddTransient<ISimpleManager<Fund>, FundManager>();
            services.AddTransient<IDataManager<Fund>, FundDataManager>();
            services.AddTransient<FundsInteractor>();
            services.AddTransient<IActivitiesUsersService, ActivitiesUsersService>();

            var automapperProfiles = new List<Profile>();
            automapperProfiles.Add(MainModule.Automapper.AutomapperConfig.GetAutomapperProfile());
            automapperProfiles.Add(Activities.Interactor.AutomapperConfig.GetAutomapperProfile());
            automapperProfiles.Add(new ViewModelsMapperProfile());
            var mappingConfig = new MapperConfiguration(mc =>
            {
                foreach (var item in automapperProfiles)
                {
                    mc.AddProfile(item);
                }
                mc.AllowNullCollections = true;
                mc.AllowNullDestinationValues = true;
                mc.EnableNullPropagationForQueryMapping = true;
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            TempDataInitializer.Initialize();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseOptions();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
