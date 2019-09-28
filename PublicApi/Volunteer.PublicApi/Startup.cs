namespace Volunteer.PublicApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Swashbuckle.AspNetCore.Swagger;
    using MainModule.Services.Implementations;
    using MainModule.Services.Interfaces;
    using AutoMapper;

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

            services.AddTransient<IUserService, UserService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var automapperProfiles = new List<Profile>();
            automapperProfiles.Add(new ModelsMapperProfile());
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
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
        }
    }
}
