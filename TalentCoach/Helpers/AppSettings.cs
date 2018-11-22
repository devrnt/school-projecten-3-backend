// The app settings class contains properties defined in the appsettings.json file and is used for accessing application settings via objects that injected into classes using the ASP.NET Core built in dependency injection. 
// For example the GebruikersController accesses app settings via an "IOptions<AppSettings> appSettings" object that is injected into the constructor.
// Mapping of configuration sections to classes is done in the ConfigureServices method of the Startup.cs file.
// POCO Object
namespace TalentCoach.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
    }
}
