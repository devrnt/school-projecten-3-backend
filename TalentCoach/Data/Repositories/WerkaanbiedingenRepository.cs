using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories
{
    public class WerkaanbiedingenRepository : IWerkaanbiedingenRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Werkaanbieding> _werkaanbiedingen;
        private readonly IWerkgeversRepository _werkgeversRepository;

        public WerkaanbiedingenRepository(ApplicationDbContext context)
        {
            _context = context;
            _werkaanbiedingen = context.Werkaanbiedingen;
            _werkgeversRepository = new WerkgeversRepository(context);
        }
        public Werkaanbieding AddWerkaanbieding(Werkaanbieding aanbieding)
        {
            aanbieding.Werkgever = _werkgeversRepository.GetWerkgever(aanbieding.Werkgever.Id);
            _werkaanbiedingen.Add(aanbieding);
            SaveChanges();
            return aanbieding;
        }

        public Werkaanbieding Delete(int id)
        {
            Werkaanbieding wa = _werkaanbiedingen.FirstOrDefault(w => w.Id == id);
            if (wa == null)
            {
                return null;
            }
            _werkaanbiedingen.Remove(wa);
            SaveChanges();
            return wa;
        }

        public List<Werkaanbieding> GetAll() => _werkaanbiedingen
                //.Include(w => w.Projecten)
                //.ThenInclude(p => p.Competenties)
                .Include(w => w.Werkgever)
                .OrderBy(wa => wa.Id)
                .ToList();

        public Werkaanbieding GetWerkaanbieding(int id) => _werkaanbiedingen
                //.Include(w => w.Projecten)
                //.ThenInclude(p => p.Competenties)
                .Include(w => w.Werkgever)
                .FirstOrDefault(w => w.Id == id);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Werkaanbieding UpdateWerkaanbieding(int id, Werkaanbieding werkaanbieding)
        {
            Werkaanbieding wa = _werkaanbiedingen.FirstOrDefault(w => w.Id == id);
            if (wa == null)
                return null;
            else
            {
                wa.Omschrijving = werkaanbieding.Omschrijving;
                //wa.Projecten = werkaanbieding.Projecten;
                SaveChanges();
            }
            return wa;
        }
    }
}
