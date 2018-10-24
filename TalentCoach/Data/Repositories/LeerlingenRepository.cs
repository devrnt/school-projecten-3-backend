using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories
{
    public class LeerlingenRepository : ILeerlingenRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly DbSet<Leerling> _leerlingen;

        public LeerlingenRepository(ApplicationDbContext context)
        {
            _context = context;
            _leerlingen = _context.Leerlingen;
        }

        public List<Leerling> GetAll()
        {
            // will need change lmao
            // enkel Richting nodig?
            return _leerlingen
                .Include(l => l.Richting)
                .Include(l => l.Competenties)
                .Include(l => l.Projecten)
                .ThenInclude(p => p.Competenties)
                .OrderBy(l => l.Id)
                .ToList();
        }

        public Leerling GetLeerling(int id)
        {
            var leerling = _leerlingen
                .Include(l => l.HuidigeWerkaanbieding)
                    .ThenInclude(hw => hw.Werkaanbieding)
                        .ThenInclude(wa => wa.Werkgever)
                .Include(l => l.GereageerdeWerkaanbiedingen)
                    .ThenInclude(bw => bw.Werkaanbieding)
                        .ThenInclude(wa => wa.Werkgever)
                .Include(l => l.Richting)
                    .ThenInclude(r => r.Activiteiten)
                    .ThenInclude(a => a.Competenties)
                .Include(l => l.Competenties)
                .Include(l => l.Projecten)
                    .ThenInclude(p => p.Competenties)
                .SingleOrDefault(l => l.Id == id);

            leerling.BewaardeWerkaanbiedingen = leerling.GereageerdeWerkaanbiedingen.Where(lw => lw.Like == Like.Yes).Select(lw => lw.Werkaanbieding).ToList();
            leerling.VerwijderdeWerkaanbiedingen = leerling.GereageerdeWerkaanbiedingen.Where(lw => lw.Like == Like.No).Select(lw => lw.Werkaanbieding).ToList();

            return leerling;
        }

        public Leerling AddLeerling(Leerling item)
        {
            _leerlingen.Add(item);
            SaveChanges();
            return item;
        }

        public Leerling UpdateLeerling(int id, Leerling item)
        {
            // this method only update leerling specifications 
            // NOT: Richting, competenties, projecten
            var leerling = GetLeerling(id);

            item.BewaardeWerkaanbiedingen.All(wa => { item.AddGereageerdeWerkaanbieding(wa, Like.Yes); return true; });
            item.VerwijderdeWerkaanbiedingen.All(wa => { item.AddGereageerdeWerkaanbieding(wa, Like.No); return true; });

            if (leerling != null)
            {
                leerling.Naam = item.Naam;
                leerling.Voornaam = item.Voornaam;
                leerling.GeboorteDatum = item.GeboorteDatum;
                leerling.Geslacht = item.Geslacht;
                leerling.Email = item.Email;
                leerling.Password = item.Password;
                leerling.HuidigeWerkaanbieding = item.HuidigeWerkaanbieding;
                leerling.GereageerdeWerkaanbiedingen.Union(item.GereageerdeWerkaanbiedingen);
                _leerlingen.Update(leerling);
                SaveChanges();
            }

            return leerling;
        }

        public Leerling Delete(int id)
        {
            var leerling = _leerlingen.Find(id);
            if (leerling == null)
            {
                return null;
            }
            _leerlingen.Remove(leerling);
            SaveChanges();
            return leerling;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
