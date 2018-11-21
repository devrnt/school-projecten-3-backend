using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain
{
    public class Werkaanbieding
    {
        #region === Properties ===
        public int Id { get; set; }
        public Werkgever Werkgever { get; set; }
        public string Omschrijving { get; set; }
        public string Tags { get; set; }
        //public List<Activiteit> Projecten { get; set; }
        #endregion

        #region === Constructor ===
        public Werkaanbieding(string omschrijving)
        {
            Omschrijving = omschrijving;
            //Projecten = new List<Activiteit>();
        }
        #endregion

        #region === Methods ===
        //public void AddProject(Activiteit project) => this.Projecten.Add(project);

        //public void RemoveProject(Activiteit project) => Projecten.Remove(project);
        #endregion

    }
}
