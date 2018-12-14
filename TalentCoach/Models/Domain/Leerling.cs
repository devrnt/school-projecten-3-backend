using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TalentCoach.Models.Domain
{
    public class Leerling
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public DateTime Aangemaakt { get; set; }
        public Geslacht Geslacht { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string InteressesOpslag { get; set; }
        [NotMapped]
        public List<string> Interesses { get; set; }
        public Richting Richting { get; set; }
        public int AantalCompetenties { get; set; }
        public IList<Werkaanbieding> BewaardeWerkaanbiedingen => GereageerdeWerkaanbiedingen.Where(lwa => lwa.Like == Like.Yes).Select(lwa => lwa.Werkaanbieding).ToList();
        public IList<Werkaanbieding> VerwijderdeWerkaanbiedingen => GereageerdeWerkaanbiedingen.Where(lwa => lwa.Like == Like.No).Select(lwa => lwa.Werkaanbieding).ToList();
        [JsonIgnore]
        public IList<LeerlingWerkaanbieding> GereageerdeWerkaanbiedingen { get; set; }
        public IList<LeerlingHoofdCompetentie> HoofdCompetenties { get; set; }
        public IList<LeerlingHoofdCompetentie> Projecten { get; set; }
        // TODO: Add wergever and stage
        public Werkgever Werkgever { get; set; }

        public Leerling(string naam, string voornaam, DateTime geboorteDatum, Geslacht geslacht, string email) : this()
        {
            Naam = naam;
            Voornaam = voornaam;
            GeboorteDatum = geboorteDatum;
            Geslacht = geslacht;
            Email = email;
            Aangemaakt = DateTime.Now;
            HoofdCompetenties = new List<LeerlingHoofdCompetentie>();
            AantalCompetenties = 0;
            Interesses = new List<string>();

        }

        public Leerling()
        {
            GereageerdeWerkaanbiedingen = new List<LeerlingWerkaanbieding>();
            if (this.InteressesOpslag == null)
            {
                this.InteressesOpslag = "";
            }
            this.UpdateIntressesFromOpslag();

        }

        [JsonConstructor]
        public Leerling(bool forJson)
        {

        }

        public void AddGereageerdeWerkaanbieding(Werkaanbieding werkaanbieding, Like like)
        {
            GereageerdeWerkaanbiedingen.Add(new LeerlingWerkaanbieding(this, werkaanbieding, like));
        }

        public void UpdateIntressesFromOpslag()
        {
            string[] array = InteressesOpslag.Split(';');
            this.Interesses = new List<string>(array).Where(x => x != "").ToList();
        }

        public void AddInteresse(string interesse)
        {
            if (this.InteressesOpslag == "")
            {
                this.InteressesOpslag += interesse;
            }
            else
            {
                this.InteressesOpslag += ";" + interesse;
            }
        }
    }
}
