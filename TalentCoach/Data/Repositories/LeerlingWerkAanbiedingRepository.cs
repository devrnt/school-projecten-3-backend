using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalentCoach.Models.Domain;
namespace TalentCoach.Data.Repositories
{
    public class LeerlingWerkAanbiedingRepository: ILeerlingWerkaanbiedingenRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Werkaanbieding> _werkaanbiedingen;
        private readonly DbSet<Leerling> _leerlingen;

        public LeerlingWerkAanbiedingRepository(ApplicationDbContext context)
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
            throw new NotImplementedException();
        }

        public LeerlingWerkaanbieding RemoveWerkAanbiedingLeerling(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
