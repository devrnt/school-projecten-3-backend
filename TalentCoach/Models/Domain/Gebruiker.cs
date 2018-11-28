using System;

namespace TalentCoach.Models.Domain
{
    public class Gebruiker
    {
        public int Id { get; set; }
        public string Gebruikersnaam { get; set; }
        public GebruikersRol GebruikersRol { get; set; }
        public int ConcreteGebruikerId { get; set; }
        public byte[] WachtwoordHash { get; set; }
        public byte[] WachtwoordSalt { get; set; }
    }
}
