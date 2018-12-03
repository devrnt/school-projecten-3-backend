using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain
{
    public interface ILeerlingenRepository
    {
        List<Leerling> GetAll();
        Leerling GetLeerling(int id);
        Leerling AddLeerling(Leerling item);
        Leerling UpdateLeerling(int id, Leerling item);
        Leerling Delete(int id);
        Leerling MaakCompetentiesVoorLeerling(int id);
        List<LeerlingHoofdCompetentie> GetLeerlingCompetenties(int leerlingId);
        void SaveChanges();
    }
}
