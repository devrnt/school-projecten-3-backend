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
        public string Password { get; set; }
        public string Interesses { get; set; }
        public Richting Richting { get; set; }
        public List<Werkaanbieding> BewaardeWerkaanbiedingen { get; set; }
        public List<Werkaanbieding> VerwijderdeWerkaanbiedingen { get; set; }
        [JsonIgnore]
        public List<LeerlingWerkaanbieding> GereageerdeWerkaanbiedingen { get; set; }
        public List<Activiteit> Competenties { get; set; }
        public List<Activiteit> Projecten { get; set; }
        // TODO: Add wergever and stage

        public Leerling(string naam, string voornaam, DateTime geboorteDatum, Geslacht geslacht, string email, string password) : this()
        {
            Naam = naam;
            Voornaam = voornaam;
            GeboorteDatum = geboorteDatum;
            Geslacht = geslacht;
            Email = email;
            Password = password;
            Aangemaakt = DateTime.Now;
        }

        public Leerling(string naam, string voornaam, DateTime geboorteDatum, Geslacht geslacht, string email, string password, string interesses) :
        this(naam, voornaam, geboorteDatum, geslacht, email, password)
        {
            Interesses = interesses;
        }

        [JsonConstructor]
        public Leerling()
        {
            GereageerdeWerkaanbiedingen = new List<LeerlingWerkaanbieding>();
            BewaardeWerkaanbiedingen = new List<Werkaanbieding>();
            VerwijderdeWerkaanbiedingen = new List<Werkaanbieding>();
            Competenties = new List<Activiteit>();
        }

        public void AddGereageerdeWerkaanbieding(Werkaanbieding werkaanbieding, Like like)
        {
            GereageerdeWerkaanbiedingen.Add(new LeerlingWerkaanbieding(this, werkaanbieding, like));

        }

        public void AddCompetentieLeerling(Activiteit activiteit){
            Competenties.Add(activiteit);
        }

    }
}
