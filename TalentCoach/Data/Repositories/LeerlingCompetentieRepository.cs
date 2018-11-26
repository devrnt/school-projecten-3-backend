using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories
{
    public class LeerlingCompetentieRepository : ILeerlingCompetentieRepository
    {

        #region helper methods
        private readonly ApplicationDbContext _context;
        private readonly DbSet<LeerlingHoofdCompetentie> _lhoofdcompetenties;
        private readonly DbSet<LeerlingDeelCompetentie> _ldeelcompetenties;

        private LeerlingDeelCompetentie FindDeelCompetentie(int leerlingIdDeelCompetentieId)
        {
            return _ldeelcompetenties
                .Include(ldc => ldc.DeelCompetentie)
                .Include(ldc => ldc.Beoordelingen)
                .Where(ldc => ldc.Id == leerlingIdDeelCompetentieId).FirstOrDefault();
        }

        private LeerlingHoofdCompetentie FindHoofdCompetentie(int leerlingIdHoofCompetentieId)
        {
            return _lhoofdcompetenties
                    .Include(hc => hc.DeelCompetenties)
                        .ThenInclude(dc => dc.DeelCompetentie)
                    .Include(hc => hc.DeelCompetenties)
                        .ThenInclude(dc => dc.Beoordelingen)
                    .Include(hc => hc.HoofdCompetentie)
                    .Where(lhc => lhc.Id == leerlingIdHoofCompetentieId).FirstOrDefault();
        }

        private LeerlingHoofdCompetentie FindHoofdFromDeel(int deelCompetentieId)
        {
            return this._lhoofdcompetenties.Where(lhc => lhc.DeelCompetenties.Any(ldc => ldc.Id == deelCompetentieId)).FirstOrDefault();
        }

        private void ControlleerHoofdCompetentieBehaald(int deelCompetentieId)
        {
            var lhc = this.FindHoofdFromDeel(deelCompetentieId);
            if (lhc.DeelCompetenties.All(ldc => ldc.Behaald == true))
            {
                lhc.Behaald = true;
            }
        }
        #endregion

        public LeerlingDeelCompetentie GetDeelCompetentie(int deelcomeptentieId)
        {
            return this.FindDeelCompetentie(deelcomeptentieId);
        }

        public LeerlingHoofdCompetentie GetHoofdCompetentie(int hoofdcomeptentieId)
        {
            return this.FindHoofdCompetentie(hoofdcomeptentieId);
        }


        // beoordeling toevoegen
        public void BeoordeelDeelCompetentie(int deelcompetentieId, BeoordelingDeelCompetentie beoordeling)
        {
            this.FindDeelCompetentie(deelcompetentieId).Beoordelingen.Add(beoordeling);
            this.SaveChanges();
        }

        // beoordeling alle deelcomeptenties toevoegen
        public void BeoordeelHoofdCompetentie(int hoofdcompetentieId, BeoordelingDeelCompetentie beoordeling)
        {
            var deelcompetenties = this.FindHoofdCompetentie(hoofdcompetentieId).DeelCompetenties.GetEnumerator();
            while (deelcompetenties.MoveNext())
            {
                var dc = deelcompetenties.Current;
                dc.Beoordelingen.Add(beoordeling);
            }
            this.SaveChanges();
        }

        //deelcompetentie behalen
        public void BehaalDeelCompetentie(int deelcompetentieId)
        {
            this.FindDeelCompetentie(deelcompetentieId).Behaald = true;
            this.ControlleerHoofdCompetentieBehaald(deelcompetentieId);
            this.SaveChanges();
        }

        //deelcompetentie verwijderen
        public void DeleteDeelCompetentie(int deelcompetentieId)
        {
            this._ldeelcompetenties.Remove(this._ldeelcompetenties.Where(ldc => ldc.Id == deelcompetentieId).FirstOrDefault());
        }

        //hoofdcompetentie verwijderen
        public void DeleteHoofdCompetentie(int hoofdCompetentieId)
        {
            this._lhoofdcompetenties.Remove(this._lhoofdcompetenties.Where(ldc => ldc.Id == hoofdCompetentieId).FirstOrDefault());
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public LeerlingCompetentieRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._ldeelcompetenties = _context.LeerlingDeelCompetenties;
            this._lhoofdcompetenties = _context.LeerlingHoofdCompetenties;
        }
    }
}
