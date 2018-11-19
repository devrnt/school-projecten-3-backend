using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using TalentCoach.Data;
using TalentCoach.Data.Repositories;
using TalentCoach.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace TalentCoach
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
            var connectionString = @"Server=localhost;Database=TalentCoach;User Id=sa;Password=NietZoIdeaal11;";
            // Use SQL Database if in Azure, otherwise, use localhost
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                                                            options.UseSqlServer(connectionString));

                // Automatically perform database migration
                services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate();

            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                       options.UseInMemoryDatabase("Competenties"));
            }
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Talent Coach API", Version = "v1" });
            });

            services.AddHttpsRedirection(option =>
            {
                option.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            });

            services.AddScoped<ICompetentiesRepository, CompetentiesRepository>();
            services.AddScoped<IActiviteitenRepository, ActiviteitenRepository>();
            services.AddScoped<IRichtingenRepository, RichtingenRepository>();
            services.AddScoped<IRichtingenRepository, RichtingenRepository>();
            services.AddScoped<ILeerlingenRepository, LeerlingenRepository>();
            services.AddScoped<IWerkaanbiedingenRepository, WerkaanbiedingenRepository>();
            services.AddScoped<IWerkgeversRepository, WerkgeversRepository>();
            services.AddScoped<IWerkspreukenRepository, WerkspreukenRepository>();
            services.AddScoped<IAlgemeneInfoRepository, AlgemeneInfoRepository>();

            services.AddTransient<TalentCoachDataInitializer>();

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TalentCoachDataInitializer talentCoachDataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Talent Coach");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();

            talentCoachDataInitializer.InitializeData();
        }
    }
}
