using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain {
	public interface ICompetentiesRepository {
		List<Competentie> GetAll();
		ActionResult<Competentie> GetCompetentie(int id);
		ActionResult<Competentie> AddCompetentie(Competentie item);
		ActionResult<Competentie> UpdateCompetentie(int id, Competentie item);
		ActionResult<Competentie> Delete(int id);
		void SaveChanges();
	}
}