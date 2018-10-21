using Microsoft.EntityFrameworkCore;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data {
	public class ApplicationDbContext : DbContext {
		public DbSet<Competentie> Competenties { get; set; }
		public DbSet<Activiteit> Activiteiten { get; set; }
		public DbSet<Richting> Richtingen { get; set; }
		public DbSet<Leerling> Leerlingen { get; set; }
        public DbSet<Werkgever> Werkgevers { get; set; }
        public DbSet<Werkaanbieding> Werkaanbiedingen { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            
		}

        public DbSet<TalentCoach.Models.Domain.Richting> Richting { get; set; }
	}
}
