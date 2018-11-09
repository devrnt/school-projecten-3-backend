using System;
namespace TalentCoach.Models.Domain
{
    public class SpecifiekeInfo
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Omschrijving { get; set; }
        public Werkgever Werkgever { get; set; }

        public SpecifiekeInfo(string titel, string omschrijving)
        {
            Titel = titel;
            Omschrijving = omschrijving;
        }

        protected SpecifiekeInfo()
        {

        }
    }
}
