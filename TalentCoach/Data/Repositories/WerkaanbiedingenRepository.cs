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
            var wa = _werkaanbiedingen.Include(eenWerkaanbieding => eenWerkaanbieding.Werkgever).FirstOrDefault(w => w.Id == id);
            var waCopy = new Werkaanbieding(wa.Omschrijving) { Id = wa.Id, Tags = wa.Tags, Werkgever = wa.Werkgever };
            if (wa == null)
            {
                return null;
            }
            _werkaanbiedingen.Remove(wa);
            SaveChanges();
            return waCopy;
        }

        public List<Werkaanbieding> GetAll()
        {
            var werkaanbiedingen = _werkaanbiedingen
                 //.Include(w => w.Projecten)
                 //.ThenInclude(p => p.Competenties)
                 .Include(w => w.Werkgever)
                 .OrderBy(wa => wa.Id)
                 .ToList();
            var werkaanbiedingenEnum = werkaanbiedingen.GetEnumerator();
            while (werkaanbiedingenEnum.MoveNext())
            {
                werkaanbiedingenEnum.Current.UpdateIntressesFromOpslag();
            }
            return werkaanbiedingen;
        }

        public Werkaanbieding GetWerkaanbieding(int id)
        {
            var werkaanbieding = _werkaanbiedingen
            //.Include(w => w.Projecten)
            //.ThenInclude(p => p.Competenties)
            .Include(w => w.Werkgever)
            .FirstOrDefault(w => w.Id == id);
            werkaanbieding.UpdateIntressesFromOpslag();
            return werkaanbieding;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Werkaanbieding UpdateWerkaanbieding(int id, Werkaanbieding werkaanbieding)
        {
            var wa = _werkaanbiedingen.Include(eenWerkaanbieding => eenWerkaanbieding.Werkgever).FirstOrDefault(w => w.Id == id);
            if (wa == null)
                return null;

            wa.Omschrijving = werkaanbieding.Omschrijving;
            wa.Tags = werkaanbieding.Tags;
            //wa.Projecten = werkaanbieding.Projecten;
            SaveChanges();

            return wa;
        }

        public List<string> GetAlleTags()
        {
            var werkaanbiedingen = this._werkaanbiedingen.ToList();
            var werkaanbiedingenEnum = werkaanbiedingen.GetEnumerator();
            while (werkaanbiedingenEnum.MoveNext())
            {
                werkaanbiedingenEnum.Current.UpdateIntressesFromOpslag();
            }
            return werkaanbiedingen.SelectMany(wa => wa.Tags).Distinct().ToList();
        }
    }
}
