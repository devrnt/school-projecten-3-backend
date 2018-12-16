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
        LeerlingWerkaanbieding DislikeWerkaanbiedingLeerling(int leerlingId, int werkaanbiedingId);
        LeerlingWerkaanbieding UndoLikeDislikeWerkaanbieding(int leerlingId, int werkaanbiedingId);
        List<Werkaanbieding> ClearVerwijderdeWerkaanbiedingen(int leerlingid);
        Werkaanbieding GeefInteressantsteWerkaanbieding(int leerlingId);
        void SaveChanges();
    }
}
