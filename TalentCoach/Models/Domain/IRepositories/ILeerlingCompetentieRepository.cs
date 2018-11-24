using System;
using System.Collections.Generic;

namespace TalentCoach.Models.Domain
{
    public interface ILeerlingCompetentieRepository
    {
        IList<LeerlingHoofdCompetentie> MaakCompetentiesNieuweLeerling(Leerling leerling);
        IList<LeerlingHoofdCompetentie> UpdateCompetentiesBijVeranderingRichting(Leerling leerling);
        void AddBeoordeling(Leerling leerling,DeelCompetentie dc, BeoordelingDeelCompetentie bd);
        void SetBehaald(Leerling leerling, DeelCompetentie dc);
        void SaveChanges();
    }
}
