using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain
{
    public interface ILeerlingWerkaanbiedingenRepository
    {
        List<LeerlingWerkaanbieding> GetAll(int leerlingid);
        LeerlingWerkaanbieding LikeWerkaanbiedingLeerling(int leerlingId, int werkaanbiedingId);
        LeerlingWerkaanbieding RemoveWerkAanbiedingLeerling(int id);
        void SaveChanges();
    }
}
