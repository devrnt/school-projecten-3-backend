namespace TalentCoach.Models.Domain
{
    public class Gebruiker
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Gebruikersnaam { get; set; }
        public byte[] WachtwoordHash { get; set; }
        public byte[] WachtwoordSalt { get; set; }
    }
}
