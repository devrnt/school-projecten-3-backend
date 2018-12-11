using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;
using System.Threading.Tasks;
using TalentCoach.Data;
using TalentCoach.Data.Repositories;
using TalentCoach.Helpers;
using TalentCoach.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace TalentCoach
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            const string connectionString = @"Server=localhost;Database=TalentCoach;User Id=sa;Password=NietZoIdeaal11;";
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
                       options.UseInMemoryDatabase("TalentCoachInMemory"));
            }
          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Talent Coach API", Version = "v1" });
            });

            services.AddCors();
            // AutoMapperProfile
            services.AddAutoMapper();

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region === Authentication config ===
            // Settings object config (appsettings.json)
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // JWT Authenticaion config
            var appSettings = appSettingsSection.Get<AppSettings>();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(a =>
            {
                a.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var gebruikerRepo = context.HttpContext.RequestServices.GetRequiredService<IGebruikersRepository>();
                        int gebruikerId = int.Parse(context.Principal.Identity.Name);
                        var gebruiker = gebruikerRepo.GetById(gebruikerId);

                        if (gebruiker == null)
                        {
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                a.RequireHttpsMetadata = false;
                a.SaveToken = true;
                a.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // Volgende lijn definieert de speling op het vervallen van de token
                    // ClockSkew = TimeSpan.Zero --> Direct na het vervallen van token --> Unauthorized
                };
            });
            #endregion

            services.AddScoped<IDeelCompetentieRepository, DeelCompetentieRepository>();
            services.AddScoped<IHoofdCompetentieRepository, HoofdCompetentieRepository>();
            services.AddScoped<ILeerlingCompetentieRepository, LeerlingCompetentieRepository>();
            services.AddScoped<IRichtingenRepository, RichtingenRepository>();
            services.AddScoped<ILeerlingenRepository, LeerlingenRepository>();
            services.AddScoped<IWerkaanbiedingenRepository, WerkaanbiedingenRepository>();
            services.AddScoped<IWerkgeversRepository, WerkgeversRepository>();
            services.AddScoped<IWerkspreukenRepository, WerkspreukenRepository>();
            services.AddScoped<IAlgemeneInfoRepository, AlgemeneInfoRepository>();
            services.AddScoped<IGebruikersRepository, GebruikersRepository>();
            services.AddScoped<IRepository<SpecifiekeInfo>, SpecifiekeInfoRepository>();

            services.AddTransient<TalentCoachDataInitializer>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, TalentCoachDataInitializer talentCoachDataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseHsts();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Talent Coach");
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // global cors policy
            app.UseCors(a => a
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            );

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            talentCoachDataInitializer.InitializeData();
        }
    }
}
