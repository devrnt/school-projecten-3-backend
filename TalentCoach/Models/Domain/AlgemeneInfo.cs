using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain
{
    public class AlgemeneInfo
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Omschrijving { get; set; }

        public AlgemeneInfo(string titel, string omschrijving)
        {
            Titel = titel;
            Omschrijving = omschrijving;
        }
    }
}
