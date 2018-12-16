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
        List<Leerling> GetByWerkgever(Werkgever werkgever);
        List<String> AddIntresseToLeerling(int leerling, Interesse interesse);
        List<String> VerwijderIntresseFromLeerling(int leerling, Interesse interesse);
        void SaveChanges();
    }
}
