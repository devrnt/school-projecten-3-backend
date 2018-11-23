using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories
{
    public class HoofdCompetentieRepository : IHoofdCompetentieRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly DbSet<HoofdCompetentie> _hoofdCompetenties;

        public HoofdCompetentieRepository(ApplicationDbContext context)
        {
            _context = context;
            _hoofdCompetenties = _context.HoofdCompetenties;
        }

        public List<HoofdCompetentie> GetAll()
        {
            return _hoofdCompetenties
                .Include(a => a.DeelCompetenties)
                    .OrderBy(a => a.Id)
                    .ToList();
        }

        public HoofdCompetentie GetActiviteit(int id)
        {
            return _hoofdCompetenties
                .Include(a => a.DeelCompetenties)
                .SingleOrDefault(a => a.Id == id);
        }

        public HoofdCompetentie AddActiviteit(HoofdCompetentie item)
        {
            _hoofdCompetenties.Add(item);
            SaveChanges();
            return item;
        }

        public HoofdCompetentie Delete(int id)
        {
            HoofdCompetentie activiteit = _hoofdCompetenties.Find(id);
            if (activiteit == null)
            {
                return null;
            }
            _hoofdCompetenties.Remove(activiteit);
            SaveChanges();
            return activiteit;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public HoofdCompetentie UpdateActiviteit(int id, HoofdCompetentie item)
        {
            HoofdCompetentie activiteit = _hoofdCompetenties.Find(id);
            if (activiteit == null)
            {
                return null;
            }
            else
            {
                activiteit.Omschrijving = item.Omschrijving;
                _hoofdCompetenties.Update(activiteit);
                SaveChanges();
            }
            return activiteit;
        }
    }
}
