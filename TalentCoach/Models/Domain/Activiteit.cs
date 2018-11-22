using System.Collections.Generic;
using System.Linq;

namespace TalentCoach.Models
{
    public class Activiteit
    {
        #region === Properties ===
        public int Id { get; set; }
        public string Omschrijving { get; set; }
        public string Graad { get; set; }
        public string BehaaldOp { get; set; }             
        public List<Competentie> Competenties { get; set; }
        public bool Behaald
        {
            get
            {
                return Competenties.Any() && Competenties.All(competentie => competentie.Behaald);
            }
        }

        public int AantalCompetenties
        {
            get
            {
                return Competenties.Count();
            }
        }
        #endregion

        #region === Constructor ===

    
        public Activiteit(string omschrijving)
        {
            Omschrijving = omschrijving;
            Competenties = new List<Competentie>();
        }

        public Activiteit(string omschrijving, string graad)
        {
            Omschrijving = omschrijving;
            Competenties = new List<Competentie>();
            Graad = graad;
        }

        public Activiteit(string omschrijving, string graad, string behaaldOp):this(omschrijving)
        {
            Graad = graad;
            BehaaldOp = behaaldOp;
        }
        #endregion

        #region === Methods === 
        public void AddCompetentie(Competentie competentie)
        {
            Competenties.Add(competentie);
        }

        public void RemoveCompetentie(Competentie competentie)
        {
            Competenties.Remove(competentie);
        }
        #endregion
    }
}
