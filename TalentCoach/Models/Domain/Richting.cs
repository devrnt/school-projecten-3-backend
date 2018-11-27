using System.Collections.Generic;

namespace TalentCoach.Models.Domain
{
    public class Richting
    {
        #region === Properties ===
        public int Id { get; set; }
        public string Naam { get; set; }
        public List<HoofdCompetentie> HoofdCompetenties { get; set; } // very important
        public string Kleur{get; set;}
        public string Icon { get; set; }
        public int AantalCompetenties { get; set;}
        #endregion

        #region === Constructor ===
        public Richting(string naam,string icon,string kleur)
        {
            Naam = naam;
            Icon = icon;
            Kleur = kleur;
            HoofdCompetenties = new List<HoofdCompetentie>();
        }

        public Richting()
        {

        }
        #endregion

        #region === Methods ===
        public void AddHoofdCompetentie(HoofdCompetentie hoofdCompetentie)
        {
            HoofdCompetenties.Add(hoofdCompetentie);
        }
        #endregion
    }
}
