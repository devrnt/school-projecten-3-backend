using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories
{
    public class SpecifiekeInfoRepository : IRepository<SpecifiekeInfo>
    {
        readonly ApplicationDbContext _applicationDbContext;
        readonly DbSet<SpecifiekeInfo> _specifiekeInfos;

        public SpecifiekeInfoRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _specifiekeInfos = applicationDbContext.SpecifiekeInfo;
        }

        public SpecifiekeInfo Add(SpecifiekeInfo toAdd)
        {
            throw new NotImplementedException();
        }

        public SpecifiekeInfo Delete(SpecifiekeInfo toDelete)
        {
            throw new NotImplementedException();
        }

        public List<SpecifiekeInfo> GetAll()
        {
            return _specifiekeInfos.ToList();
        }

        public SpecifiekeInfo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public SpecifiekeInfo Update(SpecifiekeInfo toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
