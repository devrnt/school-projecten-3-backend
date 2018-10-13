using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models {
	public class Activiteit {
		public int Id { get; set; }
		public string Omschrijving { get; set; }
		public List<Competentie> Competenties { get; set; }
		public bool Behaald {
			get {
				return  Competenties.Any() && Competenties.All(competentie => competentie.Behaald);
			}
		}
	}
}
