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
            return _leerlingen
                .Include(l => l.HuidigeWerkaanbieding)
                    .ThenInclude(wa => wa.Werkgever)
                .Include(l => l.BewaardeWerkaanbiedingen)
                    .ThenInclude(wa => wa.Werkgever)
                .Include(l => l.VerwijderdeWerkaanbiedingen)
                .Include(l => l.Richting)
                    .ThenInclude(r => r.Activiteiten)
                    .ThenInclude(a => a.Competenties)
                .Include(l => l.Competenties)
                .Include(l => l.Projecten)
                    .ThenInclude(p => p.Competenties)
                .SingleOrDefault(l => l.Id == id);
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
            Leerling leerling = _leerlingen.Find(id);
            if (leerling == null)
            {
                return null;
            }
            else
            {
                leerling.Naam = item.Naam;
                leerling.Voornaam = item.Voornaam;
                leerling.GeboorteDatum = item.GeboorteDatum;
                leerling.Geslacht = item.Geslacht;
                leerling.Email = item.Email;
                leerling.Password = item.Password;
                leerling.HuidigeWerkaanbieding = item.HuidigeWerkaanbieding;
                leerling.BewaardeWerkaanbiedingen = item.BewaardeWerkaanbiedingen;
                leerling.VerwijderdeWerkaanbiedingen = item.VerwijderdeWerkaanbiedingen;
                _leerlingen.Update(leerling);
                SaveChanges();
            }
            return leerling;
        }

        public Leerling Delete(int id)
        {
            Leerling leerling = _leerlingen.Find(id);
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
