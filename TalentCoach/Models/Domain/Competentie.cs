using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models {
	public class Competentie {
		public int Id { get; set; }
		public string Omschrijving { get; set; }
		public bool Behaald { get; set; }
		public Beoordeling Beoordeling { get; set; }
		public int AantalKeerGeëvalueerd { get; set; }

		public Competentie(string omschrijving, bool behaald=false, Beoordeling beoordeling=Beoordeling.NN,int aantalKeerGeëvalueerd=0) {
			Omschrijving = omschrijving;
			Behaald = behaald;
			Beoordeling = beoordeling;
			AantalKeerGeëvalueerd = aantalKeerGeëvalueerd;
		}
	}
}
