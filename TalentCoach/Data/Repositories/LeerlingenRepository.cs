﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories
{
    public class LeerlingenRepository : ILeerlingenRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly WerkaanbiedingenRepository _werkaanbiedingenRepository;

        private readonly DbSet<Leerling> _leerlingen;

        public LeerlingenRepository(ApplicationDbContext context)
        {
            _context = context;
            _leerlingen = _context.Leerlingen;
            _werkaanbiedingenRepository = new WerkaanbiedingenRepository(context);
        }

        public List<Leerling> GetAll()
        {
            // will need change lmao
            // enkel Richting nodig?
            return _leerlingen
                .Include(l => l.Richting)
                .OrderBy(l => l.Id)
                .ToList();
        }

        public List<Leerling> GetAll_Web()
        {
            // In web willen we geen userdata: passwoord, username, etc
            var leerlingen = _leerlingen.Select(l => new Leerling()
            {
                Id = l.Id,
                Naam = l.Naam,
                Voornaam = l.Voornaam,
                Geslacht = l.Geslacht,
                Email = l.Email,
                Richting = new Richting(){ Naam = l.Richting.Naam, Id = l.Richting.Id },
                Competenties = l.Competenties,
                Projecten = l.Projecten,
                Werkgever = l.Werkgever!=null? new Werkgever(){Naam = l.Werkgever.Naam, Id = l.Werkgever.Id}: null
            });
            return leerlingen
                .Include(l => l.Richting)
                .OrderBy(l => l.Id)
                .ToList();
        }

        public Leerling GetLeerling(int id)
        {
            var leerling = _leerlingen
                .Include(l => l.Richting)
                    .ThenInclude(r => r.HoofdCompetenties)
                        .ThenInclude(a => a.Deelcompetenties)
                .Include(l => l.GereageerdeWerkaanbiedingen)
                    .ThenInclude(bw => bw.Werkaanbieding)
                        .ThenInclude(wa => wa.Werkgever)
               
                .Include(l => l)
                .Include(l => l.Projecten)
                    .ThenInclude(p => p.Deelcompetenties)
                .SingleOrDefault(l => l.Id == id);

            if (leerling != null)
            {
                leerling.BewaardeWerkaanbiedingen = leerling.GereageerdeWerkaanbiedingen
                    .Where(lw => lw.Like == Like.Yes)
                    .Select(lw => lw.Werkaanbieding).ToList();
                leerling.VerwijderdeWerkaanbiedingen = leerling.GereageerdeWerkaanbiedingen
                    .Where(lw => lw.Like == Like.No)
                    .Select(lw => lw.Werkaanbieding).ToList();
            }

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
            if (leerling != null)
            {
                // 'maps' Bewaarde- and VerwijderdeWerkaanbiedingen to GereageerdeWerkaanbiedingen
                foreach (var wa in item.BewaardeWerkaanbiedingen)
                {
                    item.AddGereageerdeWerkaanbieding(_werkaanbiedingenRepository.GetWerkaanbieding(wa.Id), Like.Yes);
                }

                foreach (var wa in item.VerwijderdeWerkaanbiedingen)
                {
                    item.AddGereageerdeWerkaanbieding(_werkaanbiedingenRepository.GetWerkaanbieding(wa.Id), Like.No);
                }


                leerling.Naam = item.Naam;
                leerling.Voornaam = item.Voornaam;
                leerling.GeboorteDatum = item.GeboorteDatum;
                leerling.Geslacht = item.Geslacht;
                leerling.Email = item.Email;
                leerling.Interesses = item.Interesses;
                leerling.Password = item.Password;
                leerling.BewaardeWerkaanbiedingen = item.BewaardeWerkaanbiedingen;
                leerling.VerwijderdeWerkaanbiedingen = item.VerwijderdeWerkaanbiedingen;
                leerling.GereageerdeWerkaanbiedingen.Clear();
                _leerlingen.Update(leerling);
                SaveChanges();
                leerling.GereageerdeWerkaanbiedingen = item.GereageerdeWerkaanbiedingen;
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
                _leerlingen.Remove(leerling);
                SaveChanges();
            }

            return leerling;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
