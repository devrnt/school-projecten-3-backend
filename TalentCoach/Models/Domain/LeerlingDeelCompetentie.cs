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

        public Leerling Leerling
        {
            get;
            private set;
        }

        public DeelCompetentie DeelCompetentie
        {
            get;
            private set;
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

        public void addBeoordeling(BeoordelingDeelCompetentie beoordeling)
        {
            this.Beoordelingen.Add(beoordeling);
        }

        public LeerlingDeelCompetentie(Leerling l,DeelCompetentie dc)
        {
            this.Leerling = Leerling;
            this.DeelCompetentie = dc;
        }
    } 
}