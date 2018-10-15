using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
			InitializeData();
		}

		public List<Competentie> GetAll() {
			return _competenties.ToList();
		}

		public Competentie GetCompetentie(int id) {
			return _competenties.Find(id);
		}

		public Competentie AddCompetentie(Competentie item) {
			_competenties.Add(item);
			SaveChanges();
			return item;
		}

		public Competentie UpdateCompetentie(int id, Competentie item) {
			Competentie competentie = _context.Competenties.Find(id);
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
			Competentie competentie = _context.Competenties.Find(id);
			if (competentie == null) {
				return null;
			}
			_competenties.Remove(competentie);
			SaveChanges();
			return competentie;
		}

		private void InitializeData() {
			if (_competenties.Count() == 0) {
				_competenties.Add(new Competentie("Houdt zich aan de richtlijnen voor hygiëne, veiligheid en ergonomie"));
				_competenties.Add(new Competentie("Reinigt het gebruikte materieel en ontsmet indien nodig"));
				_competenties.Add(new Competentie("Ruimt de gebruikte werkpost op na elke behandeling en reinigt deze"));
				SaveChanges();
			}
		}

		public void SaveChanges() {
			_context.SaveChanges();
		}
	}
}
