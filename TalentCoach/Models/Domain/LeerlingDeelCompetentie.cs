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

        private Leerling _leerling;
        public Leerling Leerling
        {
            get { return _leerling; }
            set { _leerling = value; }
        }

        private DeelCompetentie _deelCompetentie;
        public DeelCompetentie DeelCompetentie
        {
            get { return this._deelCompetentie; }
            set { _deelCompetentie = value; }
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

        public void addBeoordeling(BeoordelingDeelCompetentie beoordeling)
        {
            this.Beoordelingen.Add(beoordeling);
        }

        public LeerlingDeelCompetentie(Leerling leerling,DeelCompetentie dc)
        {
            this.Leerling = leerling;
            this.DeelCompetentie = dc;
        }

        public LeerlingDeelCompetentie()
        {

        }
    } 
}