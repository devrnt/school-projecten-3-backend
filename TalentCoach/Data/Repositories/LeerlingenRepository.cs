using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories
{
    public class LeerlingenRepository : ILeerlingenRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly WerkaanbiedingenRepository _werkaanbiedingenRepository;
        private readonly LeerlingCompetentieRepository _leerlingCompetentiesRepository;

        private readonly DbSet<Leerling> _leerlingen;

        public LeerlingenRepository(ApplicationDbContext context)
        {
            _context = context;
            _leerlingen = _context.Leerlingen;
            _werkaanbiedingenRepository = new WerkaanbiedingenRepository(context);
            _leerlingCompetentiesRepository = new LeerlingCompetentieRepository(context);
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
                Geslacht = l.Geslacht,
                Email = l.Email,
                Richting = new Richting(){ Naam = l.Richting.Naam, Id = l.Richting.Id },
                Projecten = l.Projecten,
                Werkgever = l.Werkgever!=null? new Werkgever(){Naam = l.Werkgever.Naam, Id = l.Werkgever.Id}: null
            });
            return leerlingen
                .Include(l => l.Richting)
                .OrderBy(l => l.Id)
                .ToList();
        }


        public List<LeerlingHoofdCompetentie> GetLeerlingCompetenties(int leerlingId)
        {
            var competenties = _leerlingen
                .Include(l => l.HoofdCompetenties)
                    .ThenInclude(hc => hc.DeelCompetenties)
                        .ThenInclude(dc => dc.DeelCompetentie)
                .Include(l => l.HoofdCompetenties)
                    .ThenInclude(hc => hc.DeelCompetenties)
                        .ThenInclude(dc => dc.Beoordelingen)
                .Include(l => l.HoofdCompetenties)
                    .ThenInclude(hc => hc.HoofdCompetentie)
                .Where(l => l.Id == leerlingId).FirstOrDefault().HoofdCompetenties.ToList();
            var competentieEnum = competenties.GetEnumerator();
            while (competentieEnum.MoveNext())
            {
                var hoofdcompentie = competentieEnum.Current;
                hoofdcompentie.HoofdCompetentie.DeelCompetenties = new List<DeelCompetentie>();
            }
            return competenties;
        }

        public Leerling GetLeerling(int id)
        {
            var leerling = _leerlingen
                .Include(l => l.Richting)
                .Include(l => l.GereageerdeWerkaanbiedingen)
                    .ThenInclude(bw => bw.Werkaanbieding)
                        .ThenInclude(wa => wa.Werkgever)
                .Include(l => l.Projecten)
                     .ThenInclude(a => a.DeelCompetenties)
                .Include(l => l.HoofdCompetenties)
                    .ThenInclude(hc => hc.DeelCompetenties)
                        .ThenInclude(dc => dc.DeelCompetentie)
                .Include(l => l.HoofdCompetenties)
                    .ThenInclude(hc => hc.DeelCompetenties)
                        .ThenInclude(dc => dc.Beoordelingen)
                .Include(l => l.HoofdCompetenties)
                    .ThenInclude(hc => hc.HoofdCompetentie)
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
            leerling.Richting.HoofdCompetenties = null;
            var leerlinghoofdcompetenties = leerling.HoofdCompetenties.GetEnumerator();
            while(leerlinghoofdcompetenties.MoveNext())
            {
                var hoofdcompentie = leerlinghoofdcompetenties.Current;
                hoofdcompentie.HoofdCompetentie.DeelCompetenties  = new List<DeelCompetentie>();
            }
            return leerling;
        }

        public Leerling AddLeerling(Leerling item)
        {
            _leerlingen.Add(item);
            SaveChanges();
            return this.MaakCompetentiesVoorLeerling(item.Id);
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
                if (leerling.Richting.Id != item.Richting.Id)
                {
                    leerling.Richting = item.Richting;
                    //this._leerlingCompetentiesRepository.UpdateCompetentiesBijVeranderingRichting(leerling);
                }

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
            var leerling = _leerlingen.Where(l => l.Id == id).FirstOrDefault();
            if (leerling != null)
            {
                _leerlingen.Remove(leerling);
                SaveChanges();
            }

            return leerling;
        }

        public Leerling MaakCompetentiesVoorLeerling(int leerlingId)
        {
            // het volledige leerling object ophalen
            var leerling = this._leerlingen
                .Include(l => l.Richting)
                    .ThenInclude(r => r.HoofdCompetenties)
                               .ThenInclude(hc => hc.DeelCompetenties)
                .Where(l => l.Id == leerlingId).FirstOrDefault();
            //over alle hoofd en deelcompetenties itereren en alles verwijderen dat ongewijzigd is.
            var hoofdcompetenties = leerling.HoofdCompetenties.GetEnumerator();
            //hoofcompetenties
            while (hoofdcompetenties.MoveNext())
            {
                var lhc = hoofdcompetenties.Current;
                //als hoofdcompetenties niet behaald is bekijken we deelcompetenties
                if (!lhc.Behaald )
                {
                    var deelcompetenties = lhc.DeelCompetenties.GetEnumerator();
                    while (deelcompetenties.MoveNext())
                    {
                        var ldc = deelcompetenties.Current;
                        //als een deelcmpetentie gewijzigd is verwijderen we ze van de hoofdcompetentie
                        if (!ldc.Behaald&&ldc.Beoordelingen.Count==0)
                        {
                            //leerling.HoofdCompetenties
                                    //.FirstOrDefault(l => l.Id == lhc.Id)
                                    //.DeelCompetenties.Remove(ldc);
                        }
                    }
                    //als alle deelcompetenties ongewijzigd zijn (verwijderd) dan verwijderen we tenslotte ook de hoofdcompetentie
                    if (lhc.DeelCompetenties.Count==0)
                    {
                        //leerling.HoofdCompetenties.Remove(lhc);
                    }
                }
            }

            //nieuwe competenties toevoegen op basis van richting
            var richting = leerling.Richting;
            richting.HoofdCompetenties.ForEach(hc =>
            {

                //als er een hoofcompetentie nog aanwezig is voegen we die niet opnieuw toe
                if (!leerling.HoofdCompetenties.Any(l => l.HoofdCompetentie.Id == hc.Id)|| leerling.HoofdCompetenties.Count == 0)
                {
                    //anders voegen we hoofd en corresponderende deelcompetenties toe
                    leerling.HoofdCompetenties.Add(
                        new LeerlingHoofdCompetentie()
                        {
                            HoofdCompetentie = hc,
                            Behaald = false,
                            DeelCompetenties = hc.DeelCompetenties.Select(dc => new LeerlingDeelCompetentie()
                            {
                                DeelCompetentie = dc,
                                Behaald = false,
                                Beoordelingen = new List<BeoordelingDeelCompetentie>()
                            }).ToList()
                        }
                    );
                }
            });
            // persisteer 'update' het leerling object
            this._leerlingen.Remove(this._leerlingen.Where(l => l.Id == leerling.Id).FirstOrDefault());
            this.SaveChanges();
            this._leerlingen.Add(leerling);
            this.SaveChanges();

            return leerling;
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}
