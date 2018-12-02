using System.Collections.Generic;
using System.Linq;

namespace TalentCoach.Models
{
    public class HoofdCompetentie
    {
        #region === Properties ===
        public int Id { get; set; }
        public string Omschrijving { get; set; }
        public string Graad { get; set; }
        public IList<DeelCompetentie> DeelCompetenties { get; set; }


        public int AantalCompetenties
        {
            get
            {
                return DeelCompetenties.Count();
            }
        }
        #endregion

        #region === Constructor ===

    
        public HoofdCompetentie(){

        }
        
        public HoofdCompetentie(string omschrijving)
        {
            Omschrijving = omschrijving;
            DeelCompetenties = new List<DeelCompetentie>();
        }

        public HoofdCompetentie(string omschrijving, string graad)
        {
            Omschrijving = omschrijving;
            DeelCompetenties = new List<DeelCompetentie>();
            Graad = graad;
        }

        #endregion

        #region === Methods === 
        public void AddCompetentie(DeelCompetentie competentie)
        {
            DeelCompetenties.Add(competentie);
        }

        public void RemoveCompetentie(DeelCompetentie competentie)
        {
            DeelCompetenties.Remove(competentie);
        }
        #endregion
    }
}
