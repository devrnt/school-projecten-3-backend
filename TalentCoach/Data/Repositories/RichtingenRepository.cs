using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories
{
    public class RichtingenRepository : IRichtingenRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly DbSet<Richting> _richtingen;

        public RichtingenRepository(ApplicationDbContext context)
        {
            _context = context;
            _richtingen = context.Richtingen;
        }

        public List<Richting> GetAll()
        {
            return _richtingen
                .Include(r => r.Activiteiten)
                    .ThenInclude(a => a.Competenties)
                .OrderBy(r => r.Id)
                .ToList();
        }

        public Richting GetRichting(int id)
        {
            return _richtingen
                .Include(r => r.Activiteiten)
                    .ThenInclude(a => a.Competenties)
                .SingleOrDefault(r => r.Id == id);
        }


        public Richting AddRichting(Richting item)
        {
            _richtingen.Add(item);
            SaveChanges();
            return item;
        }

        public Richting UpdateRichting(int id, Richting item)
        {
            Richting richting = _richtingen.Find(id);
            if (richting == null)
            {
                return null;
            }
            else
            {
                richting.Naam = item.Naam;
                richting.Activiteiten = item.Activiteiten;
                _richtingen.Update(richting);
                SaveChanges();
            }

            return richting;
        }

        public Richting Delete(int id)
        {
            Richting richting = _richtingen.Find(id);
            if (richting == null)
            {
                return null;
            }
            _richtingen.Remove(richting);
            SaveChanges();
            return richting;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
