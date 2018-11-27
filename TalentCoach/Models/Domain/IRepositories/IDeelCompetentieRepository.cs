using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain
{
    public interface IDeelCompetentieRepository
    {
        List<DeelCompetentie> GetAll();
        DeelCompetentie GetCompetentie(int id);
        DeelCompetentie AddCompetentie(DeelCompetentie item);
        DeelCompetentie UpdateCompetentie(int id, DeelCompetentie item);
        DeelCompetentie Delete(int id);
        void SaveChanges();
    }
}