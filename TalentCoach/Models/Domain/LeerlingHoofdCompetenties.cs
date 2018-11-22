using System;
using System.Collections.Generic;

namespace TalentCoach.Models.Domain
{
    public class LeerlingHoofdCompetentie
    {
        public int Id
        {
            get;
            set;
        }

        public bool Behaald
        {
            get;
            set;
        }

        public DateTime DatumBehaald
        {
            get;
            set;
        }

    }
}
