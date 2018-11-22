using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models
{
    public class DeelCompetentie
    {
        #region === Properties === 
        public int Id { get; set; }
        public string Omschrijving { get; set; }
        #endregion

        #region === Constructor === 
        public DeelCompetentie(string omschrijving)
        {
            Omschrijving = omschrijving;
        }
        #endregion
    }
}
