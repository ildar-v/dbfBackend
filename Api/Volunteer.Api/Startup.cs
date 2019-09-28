namespace Volunteer.Api
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
    using Volunteer.MainModule.Automapper;
    using AutoMapper;
    using System.Collections.Generic;
    using Api.Automapper;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using Volunteer.Authentity;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
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
            services.AddTransient<ActivitiesInteractor>();
            services.AddTransient<ISimpleManager<User>, UserManager>();
            services.AddTransient<IDataManager<User>, UserDataManager>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISimpleManager<ActivitiesUsers>, ActivitiesUsersManager>();
            services.AddTransient<IDataManager<ActivitiesUsers>, ActivitiesUsersDataManager>();
            services.AddTransient<Authentification>();

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
