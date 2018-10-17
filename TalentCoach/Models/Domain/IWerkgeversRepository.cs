using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain {
    public interface IWerkgeversRepository {
        IEnumerable<Werkgever> GetAll();
        Werkgever GetWerkgever(int id);
        Werkgever AddWerkgever(Werkgever werkgever);
        Werkgever UpdateWerkgever(int id, Werkgever werkgever);
        Werkgever Delete(int id);
        void SaveChanges();

    }
}
