using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain
{
    public interface IHoofdCompetentieRepository
    {
        List<HoofdCompetentie> GetAll();
        HoofdCompetentie GetActiviteit(int id);
        HoofdCompetentie AddActiviteit(HoofdCompetentie item);
        HoofdCompetentie UpdateActiviteit(int id, HoofdCompetentie item);
        HoofdCompetentie Delete(int id);
        void SaveChanges();
    }
}
