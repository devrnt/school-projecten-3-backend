using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain
{
    public interface IActiviteitenRepository
    {
        List<Activiteit> GetAll();
        Activiteit GetActiviteit(int id);
        Activiteit AddActiviteit(Activiteit item);
        Activiteit UpdateActiviteit(int id, Activiteit item);
        Activiteit Delete(int id);
        void SaveChanges();
    }
}
