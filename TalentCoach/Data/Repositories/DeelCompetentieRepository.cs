using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories
{
    public class DeelCompetentieRepository : IDeelCompetentieRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly DbSet<DeelCompetentie> _competenties;

        public DeelCompetentieRepository(ApplicationDbContext context)
        {
            _context = context;
            _competenties = _context.DeelCompetenties;
        }

        public List<DeelCompetentie> GetAll()
        {
            return _competenties
                .OrderBy(c => c.Id)
                .ToList();
        }

        public DeelCompetentie GetCompetentie(int id)
        {
            return _competenties
                .SingleOrDefault(c => c.Id == id);
        }

        public DeelCompetentie AddCompetentie(DeelCompetentie item)
        {
            _competenties.Add(item);
            SaveChanges();
            return item;
        }

        public DeelCompetentie UpdateCompetentie(int id, DeelCompetentie item)
        {
            DeelCompetentie competentie = _competenties.Find(id);
            if (competentie == null)
            {
                return null;
            }
            else
            {
                competentie.Omschrijving = item.Omschrijving;

                _competenties.Update(competentie);
                SaveChanges();
            }
            return competentie;
        }

        public DeelCompetentie Delete(int id)
        {
            DeelCompetentie competentie = _competenties.Find(id);
            if (competentie == null)
            {
                return null;
            }
            _competenties.Remove(competentie);
            SaveChanges();
            return competentie;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
