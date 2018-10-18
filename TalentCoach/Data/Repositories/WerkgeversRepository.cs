using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories {
    public class WerkgeversRepository : IWerkgeversRepository {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Werkgever> _werkgevers;

        public WerkgeversRepository(ApplicationDbContext context) {
            _context = context;
            _werkgevers = context.Werkgevers;
        }

        public Werkgever AddWerkgever(Werkgever werkgever) {
            _werkgevers.Add(werkgever);
            SaveChanges();
            return werkgever;
        }

        public Werkgever Delete(int id) {
            Werkgever wg = _werkgevers.FirstOrDefault(w => w.Id == id);
            if (wg == null)
                return null;
            _werkgevers.Remove(wg);
            SaveChanges();
            return wg;
                
        }

        public List<Werkgever> GetAll() => _werkgevers
                .Include(w => w.Werkaanbiedingen)
                    .ThenInclude(wa => wa.Projecten)
                        .ThenInclude(p => p.Competenties)
                .OrderBy(w => w.Naam)
                .ToList();

        public Werkgever GetWerkgever(int id) => _werkgevers
                .Include(w => w.Werkaanbiedingen)
                    .ThenInclude(wa => wa.Projecten)
                        .ThenInclude(p => p.Competenties)
                .FirstOrDefault(w => w.Id == id);

        public void SaveChanges() {
            _context.SaveChanges();
        }

        public Werkgever UpdateWerkgever(int id, Werkgever werkgever) {
            Werkgever wg = _werkgevers.FirstOrDefault(w => w.Id == id);
            if (wg == null)
                return null;
            else {
                wg.Naam = werkgever.Naam;
                wg.TelefoonNummer = werkgever.TelefoonNummer;
                wg.Werkaanbiedingen = werkgever.Werkaanbiedingen;
                wg.Werkplaats = werkgever.Werkplaats;
                wg.Email = werkgever.Email;
                _werkgevers.Update(wg);
                SaveChanges();
            }
            return wg;
        }
    }
}
