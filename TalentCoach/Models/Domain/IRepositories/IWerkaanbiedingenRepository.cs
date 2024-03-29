﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain
{
    public interface IWerkaanbiedingenRepository
    {
        List<Werkaanbieding> GetAll();
        Werkaanbieding GetWerkaanbieding(int id);
        Werkaanbieding AddWerkaanbieding(Werkaanbieding aanbieding);
        Werkaanbieding UpdateWerkaanbieding(int id, Werkaanbieding werkaanbieding);
        Werkaanbieding Delete(int id);
        List<string> GetAlleTags();
        void SaveChanges();
    }
}
