namespace TalentCoach.Dtos
{
    public class GebruikerDto
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Naam { get; set; }
        public string Gebruikersnaam { get; set; }
        // Only used for model binding data in GebruikersController 
        // Not used in the http reponses
        public string Wachtwoord { get; set; }
    }
}
