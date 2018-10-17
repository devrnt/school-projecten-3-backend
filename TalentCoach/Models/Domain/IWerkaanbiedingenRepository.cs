using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain {
    public interface IWerkaanbiedingenRepository {
        IEnumerable<Werkaanbieding> GetAll();
        Werkaanbieding GetWerkaanbieding(int id);
        Werkaanbieding AddWerkaanbieding(Werkaanbieding aanbieding);
        Werkaanbieding UpdateWerkaanbieding(int id, Werkaanbieding werkaanbieding);
        Werkaanbieding Delete(int id);
        void SaveChanges();
    }
}
