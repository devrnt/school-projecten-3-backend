using System;
using System.Collections.Generic;
namespace TalentCoach.Models.Domain 
{
    public class CompetentieBeoordeling
    {
        public int Id
        {
            get;
            set;
        }

        public Leerling Leerling
        {
            get;
            set;
        }

        public DeelCompetentie Competentie
        {
            get;
            set;
        }

        public bool Geslaagd
        {
            get;
            set;
        }

        public DateTime DatumGeslaagd
        {
            get;
            set;
        }

        public IList<BeoordelingDeelCompetentie> Beoordelingen
        {
            get;
            set;
        }

    } 
}