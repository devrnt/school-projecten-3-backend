using System;
using System.Collections.Generic;
using System.Text;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Tests.Data {
	public class DummyApplicationDbContext {
		public List<Leerling> Leerlingen { get; set; }

		public DummyApplicationDbContext() {
			Leerlingen = new List<Leerling> {
				new Leerling("Dhondt", "Sam", new DateTime(1994, 1, 1), Geslacht.Man, "sam.dhondt@school.be", "samdhondt"),
				new Leerling("Haleydt", "Renaat", new DateTime(1994, 2, 2), Geslacht.Man, "renaat.haleydt@school.be", "renaathaleydt"),
				new Leerling("Stroobants", "Bruno", new DateTime(1997, 3, 3), Geslacht.Man, "bruno.stroobants@school.be", "brunostroobants"),
				new Leerling("Li", "Huhu", new DateTime(1997, 4, 4), Geslacht.Man, "li.huhu@school.be", "lihuhu"),
				new Leerling("Lisa", "De Meester", new DateTime(1993, 4, 4), Geslacht.Vrouw, "lisa.demeester@school.be", "lisademeester")

			};
		}
	}
}
