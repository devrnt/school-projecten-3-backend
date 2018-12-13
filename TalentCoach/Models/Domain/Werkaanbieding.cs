using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TalentCoach.Models.Domain
{
    public class Werkaanbieding
    {
        #region === Properties ===
        public int Id { get; set; }
        public Werkgever Werkgever { get; set; }
        public string Omschrijving { get; set; }
        [NotMapped]
        public List<string> Tags { get; set; } = new List<string>();
        [JsonIgnore]
        public string TagsStorage { get; set; }
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

        public void UpdateTags()
        {

            this.Tags = new List<string>(TagsStorage.Split());
        }
        #endregion

    }
}
