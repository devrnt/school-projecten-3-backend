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
        private readonly DbSet<Werkaanbieding> _werkaanbiedingen;
        private readonly DbSet<Leerling> _leerlingen;

        public LeerlingWerkAanbiedingenRepository(ApplicationDbContext context)
        {
            this._context = context;
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

        public LeerlingWerkaanbieding LikeWerkaanbiedingLeerling(int leerlingId, int werkaanbiedingId)
        {
            var leerling = this._leerlingen.Where(l => leerlingId == l.Id).FirstOrDefault();
            var werkaanbieding = this._werkaanbiedingen.Where(wa => wa.Id == werkaanbiedingId).FirstOrDefault();
            var leerlingwerkaanbieding = new LeerlingWerkaanbieding() { Werkaanbieding = werkaanbieding, Like = Like.Yes };
            leerling.GereageerdeWerkaanbiedingen.Add(leerlingwerkaanbieding);
            return leerlingwerkaanbieding;
        }

        public LeerlingWerkaanbieding RemoveWerkAanbiedingLeerling(int id)
        {
            throw new NotImplementedException();
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
