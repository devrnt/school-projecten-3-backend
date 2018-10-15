using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories {
	public class ActiviteitenRepository : IActiviteitenRepository {
		private readonly ApplicationDbContext _context;

		private readonly DbSet<Activiteit> _activiteiten;

		public ActiviteitenRepository(ApplicationDbContext context) {
			_context = context;
			_activiteiten = _context.Activiteiten;
		}

		public List<Activiteit> GetAll() {
			return _activiteiten
					.Include(act => act.Competenties)
					.ToList();
		}

		public Activiteit GetActiviteit(int id) {
			return _activiteiten
				.Include(a => a.Competenties)
				.SingleOrDefault(a => a.Id == id);
		}

		public Activiteit AddActiviteit(Activiteit item) {
			_activiteiten.Add(item);
			SaveChanges();
			return item;
		}

		public Activiteit Delete(int id) {
			Activiteit activiteit = _activiteiten.Find(id);
			if (activiteit == null) {
				return null;
			}
			_activiteiten.Remove(activiteit);
			SaveChanges();
			return activiteit;
		}

		public void SaveChanges() {
			_context.SaveChanges();
		}

		public Activiteit UpdateActiviteit(int id, Activiteit item) {
			Activiteit activiteit = _activiteiten.Find(id);
			if (activiteit == null) {
				return null;
			} else {
				activiteit.Omschrijving = item.Omschrijving;
				_activiteiten.Update(activiteit);
				SaveChanges();
			}
			return activiteit;
		}
	}
}
