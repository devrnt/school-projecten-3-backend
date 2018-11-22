using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories
{
    public class ActiviteitenRepository : IHoofdCompetentieRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly DbSet<HoofdCompetentie> _activiteiten;

        public ActiviteitenRepository(ApplicationDbContext context)
        {
            _context = context;
            _activiteiten = _context.Activiteiten;
        }

        public List<HoofdCompetentie> GetAll()
        {
            return _activiteiten
                    .Include(a => a.Competenties)
                    .OrderBy(a => a.Id)
                    .ToList();
        }

        public HoofdCompetentie GetActiviteit(int id)
        {
            return _activiteiten
                .Include(a => a.Competenties)
                .SingleOrDefault(a => a.Id == id);
        }

        public HoofdCompetentie AddActiviteit(HoofdCompetentie item)
        {
            _activiteiten.Add(item);
            SaveChanges();
            return item;
        }

        public HoofdCompetentie Delete(int id)
        {
            HoofdCompetentie activiteit = _activiteiten.Find(id);
            if (activiteit == null)
            {
                return null;
            }
            _activiteiten.Remove(activiteit);
            SaveChanges();
            return activiteit;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public HoofdCompetentie UpdateActiviteit(int id, HoofdCompetentie item)
        {
            HoofdCompetentie activiteit = _activiteiten.Find(id);
            if (activiteit == null)
            {
                return null;
            }
            else
            {
                activiteit.Omschrijving = item.Omschrijving;
                _activiteiten.Update(activiteit);
                SaveChanges();
            }
            return activiteit;
        }
    }
}
