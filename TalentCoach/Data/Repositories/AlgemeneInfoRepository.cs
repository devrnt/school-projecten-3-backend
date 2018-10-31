using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories
{
    public class AlgemeneInfoRepository : IAlgemeneInfoRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly DbSet<AlgemeneInfo> _algemeneInfo;

        public AlgemeneInfoRepository(ApplicationDbContext context)
        {
            _context = context;
            _algemeneInfo = _context.AlgemeneInfo;
        }

        public List<AlgemeneInfo> GetAll()
        {
            return _algemeneInfo.ToList();
        }

        public AlgemeneInfo GetAlgemeneInfo(int id)
        {
            return _algemeneInfo
                .SingleOrDefault(a => a.Id == id);
        }
        public AlgemeneInfo AddAlgemeneInfo(AlgemeneInfo item)
        {
            _algemeneInfo.Add(item);
            SaveChanges();
            return item;
        }

        public AlgemeneInfo UpdateAlgemeneInfo(int id, AlgemeneInfo item)
        {
            AlgemeneInfo algemeneInfo = _algemeneInfo.Find(id);
            if (algemeneInfo == null)
            {
                return null;
            }
            else
            {
                algemeneInfo.Titel = item.Titel;
                algemeneInfo.Omschrijving = algemeneInfo.Omschrijving;
                _algemeneInfo.Update(algemeneInfo);
                SaveChanges();
            }
            return algemeneInfo;
        }

        public AlgemeneInfo Delete(int id)
        {
            AlgemeneInfo algemeneInfo = _algemeneInfo.Find(id);
            if (algemeneInfo == null)
            {
                return null;
            }
            _algemeneInfo.Remove(algemeneInfo);
            SaveChanges();
            return algemeneInfo;
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}
