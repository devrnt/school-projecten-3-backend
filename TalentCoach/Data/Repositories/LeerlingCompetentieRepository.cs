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

        private readonly ApplicationDbContext _context;

        private readonly DbSet<LeerlingHoofdCompetentie> _lhoofdcompetenties;
        private readonly DbSet<LeerlingDeelCompetentie> _ldeelcompetenties;

        public IList<LeerlingHoofdCompetentie> MaakCompetentiesNieuweLeerling(Leerling leerling)
        {
            this.AddNieuweHoofdEnDeelOpBasisVanRichting(leerling);
            return this.GetAllLeerlingCompetenties(leerling);
        }

        public IList<LeerlingHoofdCompetentie> UpdateCompetentiesBijVeranderingRichting(Leerling leerling)
        {
            this._lhoofdcompetenties.RemoveRange(this._lhoofdcompetenties.Where(lhc => !lhc.Behaald));
            this.AddNieuweHoofdEnDeelOpBasisVanRichting(leerling);
            return this.GetAllLeerlingCompetenties(leerling);
        }

        private void AddNieuweHoofdEnDeelOpBasisVanRichting(Leerling leerling)
        {
            IList<LeerlingHoofdCompetentie> competenties = leerling.Richting.HoofdCompetenties.Select(h =>
                new LeerlingHoofdCompetentie()
                {
                    Leerling = leerling,
                    HoofdCompetentie = h,
                    Behaald = false,
                }
           ).ToList();
            _lhoofdcompetenties.AddRangeAsync(competenties.ToArray());
            this.SaveChanges();

            var deelcompetenties = leerling.Richting.HoofdCompetenties.SelectMany(hc => hc.DeelCompetenties).Select(dc =>
                new LeerlingDeelCompetentie()
                {
                    Leerling = leerling,
                    DeelCompetentie = dc,
                    Behaald = false
                }
            ).ToList();
            _ldeelcompetenties.AddRangeAsync(deelcompetenties);
            this.SaveChanges();
        }

        private void ControlleerBehaaldeDeelCompetenties(Leerling leerling)
        {
            var behaaldeDeelcompetenties = this._ldeelcompetenties.Where(ldc => ldc.Behaald).Select(ldc => ldc.DeelCompetentie.Id).ToList();
            this._ldeelcompetenties.RemoveRange(this._ldeelcompetenties.Where(ldc => !ldc.Behaald && behaaldeDeelcompetenties.Contains(ldc.DeelCompetentie.Id)).ToArray());
        }

        public void AddBeoordeling(Leerling leerling, DeelCompetentie dc, BeoordelingDeelCompetentie bd)
        {
            FindOrAddLeerlingCompetentie(leerling, dc).addBeoordeling(bd);
            this.SaveChanges();
        }

        public void SetBehaald(Leerling leerling, DeelCompetentie dc)
        {
            FindOrAddLeerlingCompetentie(leerling, dc).Behaald = true;
            this.SaveChanges();
        }

        public IList<LeerlingHoofdCompetentie> GetAllLeerlingCompetenties(Leerling fromLeerling)
        {
            // lijst van leerling-hoofdcompetenties zonder leerling-deelcompetenties
            IList<LeerlingHoofdCompetentie> competenties =
                this._lhoofdcompetenties.Where(hdc => hdc.Leerling.Id == fromLeerling.Id).ToList();
           return this.DeelCompetentiesPerHoofdCompetentie(competenties);
        }

        private IList<LeerlingHoofdCompetentie> DeelCompetentiesPerHoofdCompetentie(IList<LeerlingHoofdCompetentie> competenties)
        {
            for (int i = 0; i < competenties.Count(); i++)
            {
                var current = competenties.ElementAt(i);
                var deelCompetenties = current.HoofdCompetentie.DeelCompetenties.Select(dc => dc.Id);
                current.DeelCompetenties =
                    this._ldeelcompetenties.Where(ldc =>
                    deelCompetenties.Contains(ldc.Id)).ToList();
                competenties[i] = current;
            }
            return competenties;
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }


        private bool Exists(Leerling leerling, DeelCompetentie dc)
        {
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

        private LeerlingDeelCompetentie FindOrAddLeerlingCompetentie(Leerling leerling, DeelCompetentie dc)
        {
            if (!Exists(leerling, dc))
            {
                this._ldeelcompetenties.Add(new LeerlingDeelCompetentie(leerling, dc) { });
            }
            return this._ldeelcompetenties.First(
                lc => lc.Leerling.Id == leerling.Id && lc.DeelCompetentie.Id == dc.Id
            );
        }

        private LeerlingHoofdCompetentie FindOrAddLeerlingCompetentie(Leerling leerling, HoofdCompetentie hc)
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
