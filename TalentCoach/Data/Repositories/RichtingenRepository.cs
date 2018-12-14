﻿using Microsoft.EntityFrameworkCore;
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
                .Include(r => r.Leerkrachten)
                .ToList();
        }

        public Richting GetRichting(int id)
        {
            return _richtingen
                .Include(r => r.Leerkrachten)
                .Include(r => r.HoofdCompetenties)
                .ThenInclude(a => a.DeelCompetenties)
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
                richting.HoofdCompetenties = item.HoofdCompetenties;
                richting.Leerkrachten = item.Leerkrachten;
                _richtingen.Update(richting);
                SaveChanges();
            }

            return richting;
        }

        public Richting Delete(int id)
        {
            Richting richting2 = new Richting();
            Richting richting = _richtingen.Find(id);
            if (richting == null)
            {
                return null;
            }
            _richtingen.Remove(richting);
            SaveChanges();
            return richting2;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
