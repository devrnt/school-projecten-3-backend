using System.Collections.Generic;

namespace TalentCoach.Models.Domain
{
    public class Richting
    {
        #region === Properties ===
        public int Id { get; set; }
        public string Naam { get; set; }
        public List<HoofdCompetentie> Activiteiten { get; set; }
        public string Kleur{get; set;}
        public string Icon { get; set; }
        public int AantalCompetenties
        {
            get
            {
                int aantal = 0;
                Activiteiten.ForEach(a => aantal += a.AantalCompetenties);
                return aantal;
            }
        }
        #endregion

        #region === Constructor ===
        public Richting(string naam,string icon,string kleur)
        {
            Naam = naam;
            Icon = icon;
            Kleur = kleur;
            Activiteiten = new List<HoofdCompetentie>();
        }

        public Richting()
        {

        }
        #endregion

        #region === Methods ===
        public void AddActiviteit(HoofdCompetentie activiteit)
        {
            Activiteiten.Add(activiteit);
        }
        #endregion
    }
}
