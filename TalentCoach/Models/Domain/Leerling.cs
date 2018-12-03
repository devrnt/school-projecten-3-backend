using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
        public string Interesses { get; set; }
        public Richting Richting { get; set; }
        public int AantalCompetenties => HoofdCompetenties==null? 0: HoofdCompetenties.Count;
       
        public IList<Werkaanbieding> BewaardeWerkaanbiedingen { get; set; }
        public IList<Werkaanbieding> VerwijderdeWerkaanbiedingen { get; set; }
        [JsonIgnore]
        public List<LeerlingWerkaanbieding> GereageerdeWerkaanbiedingen { get; set; }
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
        }

        public Leerling(string naam, string voornaam, DateTime geboorteDatum, Geslacht geslacht, string email, string interesses) :
        this(naam, voornaam, geboorteDatum, geslacht, email)
        {
            Interesses = interesses;
        }

        [JsonConstructor]
        public Leerling()
        {
            GereageerdeWerkaanbiedingen = new List<LeerlingWerkaanbieding>();
            BewaardeWerkaanbiedingen = new List<Werkaanbieding>();
            VerwijderdeWerkaanbiedingen = new List<Werkaanbieding>();
        }

        public void AddGereageerdeWerkaanbieding(Werkaanbieding werkaanbieding, Like like)
        {
            GereageerdeWerkaanbiedingen.Add(new LeerlingWerkaanbieding(this, werkaanbieding, like));

        }
    }
}
