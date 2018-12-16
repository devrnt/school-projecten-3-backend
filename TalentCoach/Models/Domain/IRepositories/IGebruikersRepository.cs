using System.Collections.Generic;

namespace TalentCoach.Models.Domain
{
    public interface IGebruikersRepository
    {
        Gebruiker Authenticate(string gebruikersnaam, string wachtwoord);
        IEnumerable<Gebruiker> GetAll();
        Gebruiker GetById(int id);
        Gebruiker GetByIdNoTracking(int id);
        Gebruiker CreateGebruiker(Gebruiker gebruiker, string wachtwoord);
        void UpdateGebruiker(Gebruiker gebruikerParam, string wachtwoord = null);
        void Delete(int id);
        void SaveChanges();
    }
}
