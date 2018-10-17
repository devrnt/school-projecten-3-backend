﻿using System;
using System.Collections.Generic;

namespace TalentCoach.Models.Domain {
	public class Leerling {
		public int Id { get; set; }
		public string Naam { get; set; }
		public string Voornaam { get; set; }
		public DateTime GeboorteDatum{ get; set; }
		public DateTime Aangemaakt { get; set; }
		public Geslacht Geslacht { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public Richting Richting { get; set; }
		public List<Activiteit> Competenties { get; set; }
		public List<Activiteit> Projecten { get; set; }
		// TODO: Add wergever and stage

		public Leerling(string naam, string voornaam, DateTime geboorteDatum, Geslacht geslacht, string email, string password) {
			Naam = naam;
			Voornaam = voornaam;
			GeboorteDatum = geboorteDatum;
			Geslacht = geslacht;
			Email = email;
			Password = password;
			Aangemaakt = DateTime.Now;
		}
	}
}