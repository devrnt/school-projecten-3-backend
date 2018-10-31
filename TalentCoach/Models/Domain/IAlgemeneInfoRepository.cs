using System.Collections.Generic;

namespace TalentCoach.Models.Domain
{
    public interface IAlgemeneInfoRepository
    {
        List<AlgemeneInfo> GetAll();
        AlgemeneInfo GetAlgemeneInfo(int id);
        AlgemeneInfo AddAlgemeneInfo(AlgemeneInfo item);
        AlgemeneInfo UpdateAlgemeneInfo(int id, AlgemeneInfo item);
        AlgemeneInfo Delete(int id);
        void SaveChanges();
    }
}
