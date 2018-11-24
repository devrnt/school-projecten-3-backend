using System;
using System.Collections.Generic;

namespace TalentCoach.Models.Domain
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T toAdd);
        T Update(T toUpdate);
        T Delete(T toDelete);
        void SaveChanges();
    }
}
