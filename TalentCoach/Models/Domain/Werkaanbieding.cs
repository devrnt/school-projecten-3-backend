using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain {
    public class Werkaanbieding {
        #region === Properties ===
        public int Id { get; set; }
        public string Omschrijving { get; set; }
        public int AantalPlaatsen { get; set; }
        public DateTime BeginStage { get; set; }
        public DateTime EindeStage { get; set; }
        public List<Activiteit> Projecten { get; set; }
        public int AantalPlaatsenIngevuld { get; set; }
        #endregion

        #region === Constructor ===
        public Werkaanbieding(string omschrijving, int aantalPlaatsen, DateTime beginStage, DateTime eindStage, List<Activiteit> projecten, int aantalPlaatsenIngevuld = 0) {
            Omschrijving = omschrijving;
            AantalPlaatsen = aantalPlaatsen;
            BeginStage = beginStage;
            EindeStage = eindStage;
            Projecten = projecten;
            AantalPlaatsenIngevuld = aantalPlaatsenIngevuld;
        }
        #endregion

        #region === Methods ===
        public void AddProject(Activiteit project) {
            this.Projecten.Add(project);
        }

        public void RemoveProject(Activiteit project) {
            Projecten.Remove(project);
        }
        #endregion
    }
}
