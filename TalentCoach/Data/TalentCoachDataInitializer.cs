using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalentCoach.Models;

namespace TalentCoach.Data {
	public class TalentCoachDataInitializer {
		private readonly ApplicationDbContext _context;

		public TalentCoachDataInitializer(ApplicationDbContext context) {
			_context = context;
		}

		public void InitializeData() {
			_context.Database.EnsureDeleted();
			if (_context.Database.EnsureCreated()) {

				// Competenties
				var competentie1 = new Competentie("Houdt zich aan de richtlijnen voor hygiëne, veiligheid en ergonomie");
				var competentie2 = new Competentie("Ruimt de gebruikte werkpost op na elke behandeling en reinigt deze");
				var competentie3 = new Competentie("Reinigt het gebruikte materieel en ontsmet indien nodig");
				var competentie4 = new Competentie("Sorteert afval volgens de richtlijnen");

				var competentie5 = new Competentie("Houdt zich aan de richtlijnen voor hygiëne, veiligheid en ergonomie");
				var competentie6 = new Competentie("Ruimt de gebruikte werkpost op na elke behandeling en reinigt deze");
				var competentie7 = new Competentie("Reinigt het gebruikte materieel en ontsmet indien nodig");
				var competentie8 = new Competentie("Sorteert afval volgens de richtlijnen");


				// Activiteit
				var activiteit1 = new Activiteit("Ruimt de werkpost op en maakt hem schoon");
				activiteit1.AddCompetentie(competentie1);
				activiteit1.AddCompetentie(competentie2);
				activiteit1.AddCompetentie(competentie3);
				activiteit1.AddCompetentie(competentie4);

				var activiteit2 = new Activiteit("Neemt deel aan de organisatie van het kapsalon");
				activiteit2.AddCompetentie(competentie5);
				activiteit2.AddCompetentie(competentie6);
				activiteit2.AddCompetentie(competentie7);
				activiteit2.AddCompetentie(competentie8);

				var activiteiten = new List<Activiteit> { activiteit1, activiteit2 };

				_context.Activiteiten.AddRange(activiteiten);
				_context.SaveChanges();
			}
		}
	}
}
