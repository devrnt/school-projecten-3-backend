using System;
using System.Collections.Generic;
namespace TalentCoach.Models.Domain
{
    public class LeerlingDeelCompetentie
    {
        public int Id
        {
            get;
            set;
        }

        public DeelCompetentie DeelCompetentie
        {
            get;
            set;
        }

        public bool Behaald
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


        public LeerlingDeelCompetentie(Leerling leerling,DeelCompetentie dc)
        {
            this.DeelCompetentie = dc;
        }

        public LeerlingDeelCompetentie()
        {

        }
    } 
}