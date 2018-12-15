using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalentCoach.Models.Domain;
namespace TalentCoach.Data.Repositories
{
    public class LeerlingWerkAanbiedingenRepository: ILeerlingWerkaanbiedingenRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<LeerlingWerkaanbieding> _leerlingWerkaanbiedingen;
        private readonly DbSet<Werkaanbieding> _werkaanbiedingen;
        private readonly DbSet<Leerling> _leerlingen;

        public LeerlingWerkAanbiedingenRepository(ApplicationDbContext context)
        {
            this._context = context;
            _leerlingWerkaanbiedingen = context.LeerlingWerkaanbiedingen;
            _werkaanbiedingen = context.Werkaanbiedingen;
            _leerlingen = context.Leerlingen;
        }

        public List<LeerlingWerkaanbieding> GetAll(int leerlingid)
        {
            return this._leerlingen
                       .Where(l => l.Id == leerlingid)
                       .FirstOrDefault()
                       .GereageerdeWerkaanbiedingen
                       .Where(wa => wa.Like == Like.Yes)
                       .ToList();
        }

        public LeerlingWerkaanbieding GetLeerlingWerkaanbieding(int leerlingId, int waId)
        {
            return this._leerlingen
                       .Where(l => l.Id == leerlingId)
                       .Include(lwa => lwa.GereageerdeWerkaanbiedingen)
                       .FirstOrDefault()
                       .GereageerdeWerkaanbiedingen
                       .FirstOrDefault(lwa => lwa.Werkaanbieding.Id == waId);
        }

        public LeerlingWerkaanbieding LikeWerkaanbiedingLeerling(int leerlingId, int werkaanbiedingId)
        {
            var leerling = this._leerlingen.Where(l => leerlingId == l.Id).FirstOrDefault();
            var werkaanbieding = this._werkaanbiedingen.Where(wa => wa.Id == werkaanbiedingId).FirstOrDefault();
            var leerlingwerkaanbieding = new LeerlingWerkaanbieding(leerling,werkaanbieding,Like.Yes);
            leerling.GereageerdeWerkaanbiedingen.Add(leerlingwerkaanbieding);
            this.SaveChanges();
            return leerlingwerkaanbieding;
        }

        public LeerlingWerkaanbieding DislikeWerkaanbiedingLeerling(int leerlingId, int werkaanbiedingId)
        {
            var leerling = this._leerlingen.Where(l => leerlingId == l.Id).FirstOrDefault();
            var werkaanbieding = this._werkaanbiedingen.Where(wa => wa.Id == werkaanbiedingId).FirstOrDefault();
            var leerlingwerkaanbieding = new LeerlingWerkaanbieding(leerling,werkaanbieding,Like.No);
            this._leerlingWerkaanbiedingen.Add(leerlingwerkaanbieding);
            this.SaveChanges();
            return leerlingwerkaanbieding;
        }

        public List<Werkaanbieding> GeefInteressantsteWerkaanbieding(int leerlingId)
        {
            //NOTA: hou structuur aub met variabelen = makkelijker debuggen
            var leerling = this._leerlingen
                               .Include(l => l.GereageerdeWerkaanbiedingen)
                                    .ThenInclude(lwa => lwa.Werkaanbieding)
                               .Where(l => leerlingId == l.Id)
                               .FirstOrDefault();
            leerling.UpdateIntressesFromOpslag();
            var werkaanbiedingen = this._werkaanbiedingen
                                       .Include(wa => wa.Werkgever)
                                     //Mag niet in bewaarde werkaanbiedingen van leerling zitten
                                      .Where(wa => !(leerling.GereageerdeWerkaanbiedingen
                                            .Where(lwa => lwa.Like == Like.Yes).Select(lwa => lwa.Werkaanbieding).Any(bwa => wa.Id == bwa.Id))).ToList()
                                     //Mag niet in verwijderde werkaanbiedingen van leerling zitten
                                     .Where(wa => !leerling.GereageerdeWerkaanbiedingen
                                            .Where(lwa => lwa.Like == Like.No)
                                            .Select(lwa => lwa.Werkaanbieding).ToList().Any(bwa => wa.Id == bwa.Id))
                                       .ToList();
            //filter die eruit waar geen matching intresse is
            var werkaanbiedingenEnum = werkaanbiedingen.GetEnumerator();
            while (werkaanbiedingenEnum.MoveNext())
            {
                werkaanbiedingenEnum.Current.UpdateIntressesFromOpslag();
            }
            var werkaanbieding2 = werkaanbiedingen
                                        .Where(wa => wa.Tags.Any(
                                            t => leerling.Interesses.Any(i => i.Equals(t)))).ToList()
                                       //Geef de werkaanbieding die de meeste overeenkomstige tags / interesses heeft met de leerling
                                       .OrderByDescending(
                                           wa => wa.Tags.Count(t => leerling.Interesses.Any(i => i.Equals(t))))
                                        .ToList();
            var iterator = werkaanbieding2.GetEnumerator();
            while (iterator.MoveNext())
            {
                iterator.Current.UpdateIntressesFromOpslag();
            }
            return werkaanbieding2;
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public LeerlingWerkAanbiedingenRepository()
        {

        }
    }
}
