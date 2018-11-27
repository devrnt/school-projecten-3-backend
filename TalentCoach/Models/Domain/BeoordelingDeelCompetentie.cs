﻿using System;
namespace TalentCoach.Models.Domain
{
    public class BeoordelingDeelCompetentie
    {
        public int Id
        {
            get;
            set;
        }

        public BeoordelingScore Score
        {
            get;
            set;
        }
        public string Test
        {
            get;
            set;
        }

        public DateTime Datum
        {
            get;
            set;
        }
        public BeoordelingDeelCompetentie()
        {
            Datum = DateTime.Now;
        }
    }
}