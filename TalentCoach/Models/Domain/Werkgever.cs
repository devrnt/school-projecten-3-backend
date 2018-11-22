using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain
{
    public class Werkgever
    {
        #region === Properties ===
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Werkplaats { get; set; }
        public string Email { get; set; }
        public int TelefoonNummer { get; set; }
        #endregion

        #region === Constructor ===
        public Werkgever(string naam, string werkplaats, string email, int telefoonNummer)
        {
            Naam = naam;
            Werkplaats = werkplaats;
            Email = email;
            TelefoonNummer = telefoonNummer;
        }

        public Werkgever()
        {

        }
        #endregion

    }
}
