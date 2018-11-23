using System;
using System.Collections.Generic;

namespace TalentCoach.Models.Domain
{
    public interface ILeerlingCompetentieRepository
    {
        IList<LeerlingDeelCompetentie> GetAllDeel(Leerling from);
        IList<LeerlingHoofdCompetentie> GetAllHoofd(Leerling from);
        void AddBeoordeling(Leerling leerling,DeelCompetentie dc, BeoordelingDeelCompetentie bd);
        void SetBehaald(Leerling leerling, DeelCompetentie dc);
        void SaveChanges();
    }
}
