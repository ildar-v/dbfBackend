using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using TempDAL;
using Volunteer.Activities.Interactor;
using Volunteer.BLModels.Entities;
using Volunteer.Comments.DataManager;
using Volunteer.Comments.Entity;
using Volunteer.Comments.Manager;
using Volunteer.DirtyData;
using Volunteer.MainModule.Managers;
using Volunteer.MainModule.Managers.DataManagers;
using Volunteer.MainModule.Managers.Implementations;

namespace Volunteer.Api
{
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IDataManager<Activity>, ActivityDataManager>();
            services.AddTransient<ISimpleManager<Activity>, ActivityManager>();
            services.AddTransient<IDataManager<Comment>, CommentDataManager>();
            services.AddTransient<ISimpleManager<Comment>, CommentsManager>();
            services.AddTransient<ActivitiesInteractor>();
            ActivitiesData.InitializeTempData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
