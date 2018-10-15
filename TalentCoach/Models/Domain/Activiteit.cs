using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models {
	public class Activiteit {
		#region === Properties ===
		public int Id { get; set; }
		public string Omschrijving { get; set; }
		public List<Competentie> Competenties { get; set; }
		public bool Behaald {
			get {
				return Competenties.Any() && Competenties.All(competentie => competentie.Behaald);
			}
		}
		#endregion

		#region === Constructor ===

		public Activiteit(string omschrijving) {
			Omschrijving = omschrijving;
			Competenties = new List<Competentie>();
		}
		#endregion

		#region === Methods === 
		public void AddCompetentie(Competentie competentie) {
			Competenties.Add(competentie);
		}

		public void RemoveCompetentie(Competentie competentie) {
			Competenties.Remove(competentie);
		}
		#endregion
	}
}
