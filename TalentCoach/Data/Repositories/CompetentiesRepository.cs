using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories {
	public class CompetentiesRepository: ICompetentiesRepository {
		private readonly ApplicationDbContext _context;

		private readonly DbSet<Competentie> _competenties;

		public CompetentiesRepository(ApplicationDbContext context) {
			_context = context;
			_competenties = _context.Competenties;
		}

		public List<Competentie> GetAll() {
			return _competenties.ToList();
		}

		public Competentie GetCompetentie(int id) {
			return _competenties
				.SingleOrDefault(c => c.Id == id);
		}

		public Competentie AddCompetentie(Competentie item) {
			_competenties.Add(item);
			SaveChanges();
			return item;
		}

		public Competentie UpdateCompetentie(int id, Competentie item) {
			Competentie competentie = _competenties.Find(id);
			if (competentie == null) {
				return null;
			} else {
				competentie.Behaald = item.Behaald;
				competentie.AantalKeerGeëvalueerd = item.AantalKeerGeëvalueerd;
				competentie.Beoordeling = item.Beoordeling;
				competentie.Omschrijving = item.Omschrijving;

				_competenties.Update(competentie);
				SaveChanges();
			}
			return competentie;
		}

		public Competentie Delete(int id) {
			Competentie competentie = _competenties.Find(id);
			if (competentie == null) {
				return null;
			}
			_competenties.Remove(competentie);
			SaveChanges();
			return competentie;
		}

		public void SaveChanges() {
			_context.SaveChanges();
		}
	}
}
