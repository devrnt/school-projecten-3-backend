﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TalentCoach
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseIISIntegration()
                //.UseContentRoot(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .UseStartup<Startup>();
    }
}
