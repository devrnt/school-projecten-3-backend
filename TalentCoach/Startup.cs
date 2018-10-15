using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TalentCoach.Data;
using TalentCoach.Data.Repositories;
using TalentCoach.Models.Domain;

namespace TalentCoach {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			// Use SQL Database if in Azure, otherwise, use localhost
			if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production") {
				services.AddDbContext<ApplicationDbContext>(options =>
					   options.UseSqlServer(Configuration.GetConnectionString("MyDbConnection")));

				// Automatically perform database migration
				services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate();

			} else {
				services.AddDbContext<ApplicationDbContext>(options =>
					   options.UseInMemoryDatabase("Competenties"));
			}

			services.AddScoped<ICompetentiesRepository, CompetentiesRepository>();
			services.AddScoped<IActiviteitenRepository, ActiviteitenRepository>();
			services.AddScoped<IRichtingenRepository, RichtingenRepository>();
			services.AddScoped<IRichtingenRepository, RichtingenRepository>();
			services.AddTransient<TalentCoachDataInitializer>();

			services
				.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, TalentCoachDataInitializer talentCoachDataInitializer) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			} else {
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();

			talentCoachDataInitializer.InitializeData();
		}
	}
}
