using System;
using System.Collections.Generic;

namespace TalentCoach.Models.Domain
{
    public interface ILeerlingCompetentieRepository
    {
        LeerlingDeelCompetentie GetDeelCompetentie(int deelcomeptentieId);
        LeerlingHoofdCompetentie GetHoofdCompetentie(int hoofdcomeptentieId);
        void DeleteHoofdCompetentie(int hoofdCompetentieId);
        void DeleteDeelCompetentie(int deelcompetentieId);
        void BeoordeelDeelCompetentie(int deelcompetentieId, BeoordelingDeelCompetentie beoordeling);
        void BeoordeelHoofdCompetentie(int hoofdcompetentieId, BeoordelingDeelCompetentie beoordeling);
        void BehaalDeelCompetentie(int deelcompetentieId);

    }
}
