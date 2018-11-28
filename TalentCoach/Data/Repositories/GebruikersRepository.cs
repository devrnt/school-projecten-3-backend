using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TalentCoach.Helpers;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories
{
    public class GebruikersRepository : IGebruikersRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly DbSet<Gebruiker> _gebruikers;

        public GebruikersRepository(ApplicationDbContext context)
        {
            _context = context;
            _gebruikers = _context.Gebruikers;
        }

        public Gebruiker Authenticate(string gebruikersnaam, string wachtwoord)
        {
            if (string.IsNullOrEmpty(gebruikersnaam) || string.IsNullOrEmpty(wachtwoord))
            {
                return null;
            }

            var gebruiker = _gebruikers.SingleOrDefault(g => g.Gebruikersnaam == gebruikersnaam);

            // Check of gebruikersnaam bestaat
            if (gebruiker == null)
                return null;

            // Check of wachtwoord juist is
            if (!VerifyWachtwoordHash(wachtwoord, gebruiker.WachtwoordHash, gebruiker.WachtwoordSalt))
                return null;

            // authentication successful
            return gebruiker;
        }

        public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruikers;
        }

        public Gebruiker GetById(int id)
        {
            return _gebruikers.Find(id);
        }

        public Gebruiker CreateGebruiker(Gebruiker gebruiker, string wachtwoord)
        {
            // Validatie
            if (string.IsNullOrWhiteSpace(wachtwoord))
                throw new AppException("Wachtwoord is vereist");

            if (_gebruikers.Any(x => x.Gebruikersnaam == gebruiker.Gebruikersnaam))
                throw new AppException($"Gebruikersnaam {gebruiker.Gebruikersnaam} is al in gebruik");

            byte[] wachtwoordHash;
            byte[] wachtwoordSalt;

            // keyword 'out' --> lets you pass an argument to a method by reference rather than by value.
            CreatePasswordHash(wachtwoord, out wachtwoordHash, out wachtwoordSalt);

            gebruiker.WachtwoordHash = wachtwoordHash;
            gebruiker.WachtwoordSalt = wachtwoordSalt;

            _gebruikers.Add(gebruiker);

            SaveChanges();
            return gebruiker;
        }

        public void UpdateGebruiker(Gebruiker gebruikerParam, string wachtwoord = null)
        {
            var gebruiker = _gebruikers.Find(gebruikerParam.Id);

            if (gebruiker == null)
                throw new AppException("Gebruiker niet gevonden");

            if (gebruikerParam.Gebruikersnaam != gebruiker.Gebruikersnaam)
            {
                // Gebruikersnaam is veranderd, dus valideer of de nieuwe naam reeds in gebruik is
                if (_gebruikers.Any(g => g.Gebruikersnaam == gebruikerParam.Gebruikersnaam))
                    throw new AppException("Gebruikersnaam " + gebruikerParam.Gebruikersnaam + " is al in gebruik");
            }

            // Update gebruiker attributen
            gebruiker.ConcreteGebruikerId = gebruikerParam.ConcreteGebruikerId;
            gebruiker.Gebruikersnaam = gebruikerParam.Gebruikersnaam;

            // Update wachtwoord als het ingegeven is anders gebruik vorige
            if (!string.IsNullOrWhiteSpace(wachtwoord))
            {
                byte[] wachtwoordHash;
                byte[] wachtwoordSalt;
                CreatePasswordHash(wachtwoord, out wachtwoordHash, out wachtwoordSalt);

                gebruiker.WachtwoordHash = wachtwoordHash;
                gebruiker.WachtwoordSalt = wachtwoordSalt;
            }

            _gebruikers.Update(gebruiker);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var gebruiker = _gebruikers.Find(id);
            if (gebruiker != null)
            {
                _gebruikers.Remove(gebruiker);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


        #region === Help methods ===
        private static void CreatePasswordHash(string wachtwoord, out byte[] wachtwoordHash, out byte[] wachtwoordSalt)
        {
            if (wachtwoord == null) throw new ArgumentNullException("wachtwoord");
            if (string.IsNullOrWhiteSpace(wachtwoord)) throw new ArgumentException("Value mag niet leeg zijn", "wachtwoord");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                wachtwoordSalt = hmac.Key;
                wachtwoordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(wachtwoord));
            }
        }

        private static bool VerifyWachtwoordHash(string wachtwoord, byte[] storedHash, byte[] storedSalt)
        {
            if (wachtwoord == null) throw new ArgumentNullException("wachtwoord");
            if (string.IsNullOrWhiteSpace(wachtwoord)) throw new ArgumentException("Value mag niet leeg zijn", "wachtwoord");
            if (storedHash.Length != 64) throw new ArgumentException("Ongeldige lengte van wachtwoord hash (64 bytes verwacht)", "wachtwoordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Ongeldige lengte van wachtwoord hash (128 bytes verwacht)", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(wachtwoord));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }
        #endregion
    }
}
