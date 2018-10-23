using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain
{
    public interface ICompetentiesRepository
    {
        List<Competentie> GetAll();
        Competentie GetCompetentie(int id);
        Competentie AddCompetentie(Competentie item);
        Competentie UpdateCompetentie(int id, Competentie item);
        Competentie Delete(int id);
        void SaveChanges();
    }
}