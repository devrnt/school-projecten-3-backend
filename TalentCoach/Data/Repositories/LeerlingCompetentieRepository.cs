using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories
{
    public class LeerlingCompetentieRepository: ILeerlingCompetentieRepository
    {

        private readonly ApplicationDbContext _context;

        private readonly DbSet<LeerlingHoofdCompetentie> _lhoofdcompetenties;
        private readonly DbSet<LeerlingDeelCompetentie> _ldeelcompetenties;

        public void AddBeoordeling(Leerling leerling, DeelCompetentie dc, BeoordelingDeelCompetentie bd)
        {
            FindOrAddLeerlingComponent(leerling,dc).addBeoordeling(bd);
            this.SaveChanges();
        }

        public void SetBehaald(Leerling leerling, DeelCompetentie dc)
        {
            FindOrAddLeerlingComponent(leerling,dc).Geslaagd = true;
            this.SaveChanges();
        }

        public IList<LeerlingDeelCompetentie> GetAllDeel(Leerling from)
        {

            return this._ldeelcompetenties.Where(ldc => ldc.Leerling.Id == from.Id).ToList();
        }

        public IList<LeerlingHoofdCompetentie> GetAllHoofd(Leerling from)
        {
            return this._lhoofdcompetenties.Where(hdc => hdc.Leerling.Id == from.Id).ToList();
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }


        private bool Exists(Leerling leerling, DeelCompetentie dc) {
           return this._ldeelcompetenties.Any(
              ldc => ldc.Leerling.Id == leerling.Id &&
              ldc.DeelCompetentie.Id == dc.Id
          );
        }

        private bool Exists(Leerling leerling, HoofdCompetentie hc)
        {
            return this._lhoofdcompetenties.Any(
              lhc => lhc.Leerling.Id == leerling.Id &&
                lhc.HoofdCompetentie.Id == hc.Id
          );
        }

        private LeerlingDeelCompetentie FindOrAddLeerlingComponent(Leerling leerling, DeelCompetentie dc){
            if (!Exists(leerling, dc))
            {
                this._ldeelcompetenties.Add(new LeerlingDeelCompetentie(leerling, dc) { });
            }
            return this._ldeelcompetenties.First(
                lc => lc.Leerling.Id == leerling.Id && lc.DeelCompetentie.Id == dc.Id
            );
        }

        private LeerlingHoofdCompetentie FindOrAddLeerlingComponent(Leerling leerling, HoofdCompetentie hc)
        {
            if (!Exists(leerling, hc))
            {
                this._lhoofdcompetenties.Add(new LeerlingHoofdCompetentie(leerling, hc) { });
            }
            return this._lhoofdcompetenties.First(
                lc => lc.Leerling.Id == leerling.Id && lc.HoofdCompetentie.Id == hc.Id
            );
        }

        public LeerlingCompetentieRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._ldeelcompetenties = _context.LeerlingDeelCompetenties;
            this._lhoofdcompetenties = _context.LeerlingHoofdCompetenties;
        }
    }
}
