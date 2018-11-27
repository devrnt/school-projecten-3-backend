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

        private bool _behaald;
        public bool Behaald
        {
            get
            {
                return this._behaald;
            }
            set 
            {
                this._behaald = value;
                DatumGeslaagd = DateTime.Now;
            }
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